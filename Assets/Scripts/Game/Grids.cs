using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grids : MonoBehaviour {

    public int grid_sizes;

    private float start_time;

    public int total_words;

    public GridScript character_grid;
    public GridScript pinying_grid;
    public GridScript english_grid;

    public bool load_settings;

    private ChineseEntry last_entry;
    private int initial_count;

    // private List<ChineseEntry> all_chinese_entries;
    private List<ChineseEntry> remaining_chinese_entries;
    private List<ChineseEntry> active_chinese_entries;
    private GameSettings game_settings;

    private StatusText status_text;

    void Awake() {
        active_chinese_entries = new List<ChineseEntry>();
        status_text = GameObject.FindObjectOfType<StatusText>();

        game_settings = GameObject.FindObjectOfType<GameSettings>();
        if (game_settings != null) {
            total_words = game_settings.TotalWords;
            print("Found GameSettings, assigning total words: " + total_words);
        }
        else {
            print("Didn't find GameSettings, using default words");
        }
    }

    void Start() {

        start_time = Time.time;

        remaining_chinese_entries = Shuffle(AnkiParser.ParseChineseEntries()).GetRange(0, total_words);
        // remaining_chinese_entries = all_chinese_entries;

        initial_count = remaining_chinese_entries.Count;

        FillGrids();
    }

    public void FillGrids() {

        int fill_count = System.Math.Min(grid_sizes, remaining_chinese_entries.Count);

        for (int i = 0; i < fill_count; i++) {
            active_chinese_entries.Add(remaining_chinese_entries[i]);
        }

        foreach (ChineseEntry entry in active_chinese_entries) {
            remaining_chinese_entries.Remove(entry);
        }

        character_grid.Build(this, Shuffle(active_chinese_entries), GridLanguage.character);
        pinying_grid.Build(this, Shuffle(active_chinese_entries), GridLanguage.pinying);
        english_grid.Build(this, Shuffle(active_chinese_entries), GridLanguage.english);
    }

    private List<ChineseEntry> Shuffle(List<ChineseEntry> alpha) {
        for (int i = 0; i < alpha.Count; i++) {
            ChineseEntry temp = alpha[i];
            int randomIndex = Random.Range(i, alpha.Count);
            alpha[i] = alpha[randomIndex];
            alpha[randomIndex] = temp;
        }
        return alpha;
    }

    public void CellActivated() {

        if (character_grid.ActiveCell == null || pinying_grid.ActiveCell == null || english_grid.ActiveCell == null) {
            return;
        }

        ChineseEntry active_character = character_grid.ActiveCell.ChineseEntry;
        ChineseEntry active_pinying = pinying_grid.ActiveCell.ChineseEntry;
        ChineseEntry active_english = english_grid.ActiveCell.ChineseEntry;

        if (active_character == active_pinying && active_pinying == active_english) {
            print("It is a match!");
            character_grid.CorrectSelection();
            pinying_grid.CorrectSelection();
            english_grid.CorrectSelection();
            last_entry = active_character;
            active_chinese_entries.Remove(active_character);
        }
    }

    void Update() {

        if (active_chinese_entries.Count == 0) {
            FillGrids();
        }

        UpdateStatusText();
    }

    private void UpdateStatusText() {

        int remaining_entries = remaining_chinese_entries.Count;
        int cleared_entries = initial_count - remaining_entries - active_chinese_entries.Count;

        // float elapsed_time = Time.time - start_time;

        float rate = (float)cleared_entries / Time.time;

        string new_status_text = "Cleared: " + cleared_entries + " / " + initial_count + "\n" +
                                 "Elapsed time: " + (int)Time.time + "\n" +
                                 "Rate: " + System.Math.Round(rate, 2) + "\n\n" +
                                 "Last word: \n";

        string last_entry_text = "";
        if (last_entry != null) {
            last_entry_text = last_entry.character + "\n" + last_entry.pinying + "\n" + last_entry.english;
        }

        status_text.SetText(
            new_status_text + last_entry_text
        );
    }
}
