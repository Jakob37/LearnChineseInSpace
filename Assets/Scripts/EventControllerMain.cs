using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventControllerMain : MonoBehaviour {

    public int total_words;

    private Character current_character;
    private DecisionGrid decision_grid;
    private DecisionButton[] decision_buttons;
    private int nbr_choices;
    private GameSettings game_settings;
    private MyCharacters my_characters;
    private CurrCharText curr_char_text;

    private bool ButtonsAssigned {
        get {
            for (var j = 0; j < nbr_choices; j++) {
                if (decision_buttons[j].GetText() != "-") {
                    return true;
                }
            }
            return false;
        }
    }

    void Awake() {

        decision_grid = FindObjectOfType<DecisionGrid>();
        game_settings = FindObjectOfType<GameSettings>();
        my_characters = gameObject.GetComponent<MyCharacters>();
        curr_char_text = FindObjectOfType<CurrCharText>();
    }

    void Start() {
        decision_buttons = decision_grid.gameObject.GetComponentsInChildren<DecisionButton>();
        nbr_choices = decision_buttons.Length;
        if (game_settings != null) {
            my_characters.Initialize(game_settings.TotalWords);
        }
        else {
            my_characters.Initialize(10);
        }
        ClearDecisionButtons();

        for (var i = 0; i < 5; i++) {
            TrigStep();
        }
    }

    private void ClearDecisionButtons() {
        for (var j = 0; j < nbr_choices; j++) {
            decision_buttons[j].SetText("-");
        }
        curr_char_text.SetText("-");
    }

    private void AssignDecisionButtons(CharacterType char_type, ChineseEntry picked=null) {

        List<ChineseEntry> curr_entries = new List<ChineseEntry>();
        if (picked != null) {
            curr_entries.Add(picked);
        }

        List<ChineseEntry> shuffled_entries = my_characters.RequestEntries(nbr_choices, studied_only:false);
        int i = 0;
        while (curr_entries.Count < nbr_choices) {
            ChineseEntry choice_entry = shuffled_entries[i];
            curr_entries.Add(choice_entry);
            i++;
        }

        curr_entries = MyUtils.Shuffle(curr_entries);
        for (var j = 0; j < nbr_choices; j++) {

            ChineseEntry entry = curr_entries[j];
            string button_text = GetEntryText(entry, char_type);
            decision_buttons[j].SetText(button_text);
        }
    }

    private string GetEntryText(ChineseEntry entry, CharacterType char_type) {
        string entry_text;
        switch (char_type) {
            case CharacterType.English:
                entry_text = entry.english;
                break;
            case CharacterType.Pinying:
                entry_text = entry.pinying;
                break;
            default:
                throw new System.Exception("Unknown char_type: " + char_type);
        }
        return entry_text;
    }

    public void CharacterTriggered(Character character) {
        if (ButtonsAssigned) {
            // Trig step when buttons assigned
            TrigStep();
        }
        AssignDecisionButtons(character.CharType, character.ChineseEntry);
        current_character = character;
    }

    public void DecisionButtonTriggered(DecisionButton button) {

        string correct_text = GetEntryText(current_character.ChineseEntry, current_character.CharType);
        if (button.GetText() == correct_text) {
            print("Correct guess!");
            Destroy(current_character.gameObject);
        }
        else {
            print("Incorrect guess!");
            current_character.IncorrectGuess();
        }
        ClearDecisionButtons();
        TrigStep();
    }

    public void TrigStep() {

        print("Step trigged!");
        Character[] enemies = FindObjectsOfType<Character>();
        foreach (Character enemy in enemies) {
            // Movement enemy_movement = enemy.transform.gameObject.GetComponent<Movement>();
            enemy.Step();
        }

        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners) {
            spawner.TrigStep();
        }
    }
}
