﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventControllerMain : MonoBehaviour {

    public int total_words;
    public string text_source;

    private List<ChineseEntry> entries;
    private Dictionary<string, ChineseEntry> entry_map;
    private Character current_character;

    private DecisionGrid decision_grid;
    private DecisionButton[] decision_buttons;
    private int nbr_choices;
    private TextLoader text_loader;

    void Awake() {

        entry_map = new Dictionary<string, ChineseEntry>();
        text_loader = FindObjectOfType<TextLoader>();
        decision_grid = FindObjectOfType<DecisionGrid>();
    }

    void Start() {
        decision_buttons = decision_grid.gameObject.GetComponentsInChildren<DecisionButton>();
        nbr_choices = decision_buttons.Length;
        List<ChineseEntry> all_entries = text_loader.ParseChineseEntries(text_source);
        entries = all_entries;
        ClearDecisionButtons();
    }

    private void ClearDecisionButtons() {
        for (var j = 0; j < nbr_choices; j++) {
            decision_buttons[j].SetText("-");
        }
    }

    private void AssignDecisionButtons(ChineseEntry picked=null) {

        List<ChineseEntry> curr_entries = new List<ChineseEntry>();

        if (picked != null) {
            curr_entries.Add(picked);
        }

        List<ChineseEntry> shuffled_entries = MyUtils.Shuffle(entries);

        int i = 0;
        while (curr_entries.Count < nbr_choices) {
            ChineseEntry choice_entry = shuffled_entries[i];
            curr_entries.Add(choice_entry);
            i++;
        }

        curr_entries = MyUtils.Shuffle(curr_entries);

        for (var j = 0; j < nbr_choices; j++) {
            ChineseEntry entry = curr_entries[j];
            decision_buttons[j].SetText(entry.english);
        }
    }

    public void CharacterTriggered(Character character) {
        AssignDecisionButtons(character.ChineseEntry);
        current_character = character;
    }

    public void DecisionButtonTriggered(DecisionButton button) {
        if (button.GetText() == current_character.english_meaning) {
            print("Correct guess!");
            Destroy(current_character.gameObject);
            ClearDecisionButtons();
        }
        else {
            print("Incorrect guess!");
        }
    }

    public void TrigStep() {

        print("Step trigged!");
        BasicEnemy[] enemies = FindObjectsOfType<BasicEnemy>();
        foreach (BasicEnemy enemy in enemies) {
            Movement enemy_movement = enemy.transform.gameObject.GetComponent<Movement>();
            enemy_movement.Step();
        }

        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners) {
            spawner.TrigStep();
        }
    }
}
