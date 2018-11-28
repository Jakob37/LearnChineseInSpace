using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grids : MonoBehaviour {

    public int grid_sizes;

    public GridScript character_grid;
    public GridScript pinying_grid;
    public GridScript english_grid;

    private List<ChineseEntry> all_chinese_entries;
    private List<ChineseEntry> active_chinese_entries;

    void Start() {

        active_chinese_entries = new List<ChineseEntry>();
        all_chinese_entries = AnkiParser.ParseChineseEntries();

        for (int i = 0; i < grid_sizes; i++) {
            active_chinese_entries.Add(all_chinese_entries[i]);
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
            print("HOORAY!");
            character_grid.CorrectSelection();
            pinying_grid.CorrectSelection();
            english_grid.CorrectSelection();
        }
    }

    void Update() {

        if (character_grid.HasActiveCell) {
            // print(character_grid.ActiveCell);
        }

    }
}
