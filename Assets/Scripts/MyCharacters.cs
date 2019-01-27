using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacters : MonoBehaviour
{
    public string text_source;

    private List<ChineseEntry> all_entries;
    private Dictionary<string, ChineseEntry> study_entries;
    private TextLoader text_loader;
    private GameSettings game_settings;

    private const int score_threshold = 1;

    public int NumberEntries {
        get {
            return study_entries.Count;
        }
    }

    public int NumberActiveEntries {
        get {
            return ActiveEntries.Count;
        }
    }

    public List<ChineseEntry> AllEntries {
        get {
            return all_entries;
        }
    }

    void Awake() {
        study_entries = new Dictionary<string, ChineseEntry>();
        text_loader = FindObjectOfType<TextLoader>();
        game_settings = FindObjectOfType<GameSettings>();
    }

    private Dictionary<string, ChineseEntry> ActiveEntries {
        get {
            Dictionary<string, ChineseEntry> active_entries = new Dictionary<string, ChineseEntry>();
            foreach (string key in study_entries.Keys) {
                ChineseEntry entry = study_entries[key];
                if (entry.GetTotalScore() <= score_threshold) {
                    active_entries[key] = entry;
                }
            }
            return active_entries;
        }
    }

    public void Initialize(int total_words, bool do_radical_subset=true) {

        all_entries = text_loader.ParseChineseEntries(text_source);

        List<ChineseEntry> study_entry_list;
        if (!do_radical_subset) {
            study_entry_list = MyUtils.Shuffle(all_entries).GetRange(0, total_words);
        }
        else {
            study_entry_list = new List<ChineseEntry>();
            List<string> target_radicals = game_settings.SelectedRadicals;
            foreach (ChineseEntry entry in all_entries) {
                if (target_radicals.Contains(entry.radical)) {
                    study_entry_list.Add(entry);
                }
            }
        }

        foreach (ChineseEntry entry in study_entry_list) {
            study_entries.Add(entry.character, entry);
        }
    }

    public void RecordGuess(string character, bool correct, CharacterType char_type) {
        if (char_type == CharacterType.English) {
            study_entries[character].AddGuessEnglish(correct);
        }
        else if (char_type == CharacterType.Pinying) {
            study_entries[character].AddGuessPinyin(correct);
        }
        else {
            throw new System.Exception("Unknown char_type: " + char_type);
        }
    }

    private void RemoveEntry(string character) {
        print(study_entries.Keys);
        study_entries.Remove(character);
        print(study_entries.Keys);
    }

    public string GuessStats(string character) {

        string english_stats = study_entries[character].english_correct_guesses + "/" +
                study_entries[character].english_incorrect_guesses;
        string pinyin_stats = study_entries[character].pinyin_correct_guesses + "/" +
                study_entries[character].pinyin_incorrect_guesses;
        return english_stats + " " + pinyin_stats;
    }

    public ChineseEntry RequestEntry() {
        List<string> active_entries_keys = new List<string>(ActiveEntries.Keys);
        int rand_val = Random.Range(0, active_entries_keys.Count);
        return study_entries[active_entries_keys[rand_val]];
    }

    public List<ChineseEntry> RequestEntries(int count, bool studied_only = true) {

        var entries = new List<ChineseEntry>();
        if (studied_only) {
            List<string> active_entries_keys = new List<string>(ActiveEntries.Keys);
            var shuffled_keys = MyUtils.Shuffle(active_entries_keys);
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

}
