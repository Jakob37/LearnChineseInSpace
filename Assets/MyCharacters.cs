using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacters : MonoBehaviour
{
    public string text_source;

    private List<ChineseEntry> all_entries;
    private Dictionary<string, ChineseEntry> study_entries;
    private TextLoader text_loader;

    public int NumberEntries {
        get {
            return study_entries.Count;
        }
    }

    void Awake() {
        study_entries = new Dictionary<string, ChineseEntry>();
        text_loader = FindObjectOfType<TextLoader>();
    }

    public void Initialize(int total_words) {
        all_entries = text_loader.ParseChineseEntries(text_source);
        var study_entry_list = MyUtils.Shuffle(all_entries).GetRange(0, total_words);
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

    public string GuessStats(string character) {

        string english_stats = study_entries[character].english_correct_guesses + "/" +
                study_entries[character].english_incorrect_guesses;
        string pinyin_stats = study_entries[character].pinyin_correct_guesses + "/" +
                study_entries[character].pinyin_incorrect_guesses;
        return english_stats + " " + pinyin_stats;
    }

    public ChineseEntry RequestEntry() {
        int rand_val = Random.Range(0, 10);
        List<string> study_entry_keys = new List<string>(study_entries.Keys);
        return study_entries[study_entry_keys[rand_val]];
    }

    public List<ChineseEntry> RequestEntries(int count, bool studied_only = true) {

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

}
