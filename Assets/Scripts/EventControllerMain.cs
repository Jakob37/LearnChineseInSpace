using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventControllerMain : MonoBehaviour {

    public int total_words;
    public string text_source;

    // private List<ChineseEntry> study_entries;
    private List<ChineseEntry> all_entries;
    private Dictionary<string, ChineseEntry> study_entries;

    private Character current_character;
    private DecisionGrid decision_grid;
    private DecisionButton[] decision_buttons;
    private int nbr_choices;
    private TextLoader text_loader;
    private GameSettings game_settings;

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

        study_entries = new Dictionary<string, ChineseEntry>();
        text_loader = FindObjectOfType<TextLoader>();
        decision_grid = FindObjectOfType<DecisionGrid>();
        game_settings = FindObjectOfType<GameSettings>();
    }

    void Start() {
        decision_buttons = decision_grid.gameObject.GetComponentsInChildren<DecisionButton>();
        nbr_choices = decision_buttons.Length;
        all_entries = text_loader.ParseChineseEntries(text_source);
        var study_entry_list = MyUtils.Shuffle(all_entries).GetRange(0, game_settings.TotalWords);
        foreach (ChineseEntry entry in study_entry_list) {
            study_entries.Add(entry.character, entry);
        }

        ClearDecisionButtons();
    }

    public ChineseEntry RequestEntry() {
        int rand_val = Random.Range(0, 10);
        print("Random val: " + rand_val);
        List<string> study_entry_keys = new List<string>(study_entries.Keys);
        return study_entries[study_entry_keys[rand_val]];
    }

    public List<ChineseEntry> RequestEntries(int count, bool studied_only=true) {

        var entries = new List<ChineseEntry>();
        if (studied_only) {
            List<string> study_entry_keys = new List<string>(study_entries.Keys);
            var shuffled_keys = MyUtils.Shuffle(study_entry_keys);
            for (var i = 0; i < count; i++) {
                var curr_key = shuffled_keys[i];
                entries.Add(study_entries[curr_key]);
            }
        }
        else {
            entries = MyUtils.Shuffle(all_entries).GetRange(0, count);
        }

        return entries;
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

        // List<ChineseEntry> shuffled_entries = MyUtils.Shuffle(study_entries);
        List<ChineseEntry> shuffled_entries = RequestEntries(nbr_choices, studied_only:false);
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
        if (ButtonsAssigned) {
            // Trig step when buttons assigned
            TrigStep();
        }
        AssignDecisionButtons(character.ChineseEntry);
        current_character = character;
    }

    public void DecisionButtonTriggered(DecisionButton button) {

        if (button.GetText() == current_character.english_meaning) {
            print("Correct guess!");
            Destroy(current_character.gameObject);
        }
        else {
            print("Incorrect guess!");
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
