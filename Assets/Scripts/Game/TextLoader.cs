using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public enum TextSource {
    OldAnki,
    HalfThreePigs
}

public class TextLoader : MonoBehaviour {

    private List<String[]> word_entries;
    private List<ChineseEntry> chinese_entries;

    public Boolean use_anki_format;

    // public static TextSource text_source = TextSource.HalfThreePigs;

    public List<ChineseEntry> ParseChineseEntries(string text_source) {

        word_entries = new List<String[]>();
        chinese_entries = new List<ChineseEntry>();

        if (use_anki_format) {
            word_entries = ParseStoryEntities(text_source);

            foreach (String[] word_entry in word_entries) {

                String raw_chinese_char = word_entry[1];
                String raw_pinying = word_entry[2];
                String raw_english = word_entry[3];

                String parsed_chinese_char = Regex.Replace(raw_chinese_char, "<.*?>", "");
                String parsed_english = Regex.Replace(Regex.Replace(raw_english, "•.*", ""), "<CC>", "");
                ChineseEntry entry = new ChineseEntry(parsed_chinese_char, raw_pinying, parsed_english);
                chinese_entries.Add(entry);

            }
        }
        else {
            word_entries = MyUtils.ParseTextToSplitList(text_source, "\t", expected_length : 3, enforce_expected_length : true);
            foreach (String[] word_entry in word_entries) {
                String raw_chinese_char = word_entry[0];
                String raw_pinying = word_entry[1];
                String raw_english = word_entry[2];
                // print(raw_chinese_char + " " + raw_pinying + " " + raw_english);

                ChineseEntry entry = new ChineseEntry(raw_chinese_char, raw_pinying, raw_english);
                chinese_entries.Add(entry);
            }
        }
        return chinese_entries;
    }

    private List<String[]> ParseStoryEntities(string resource_name, string splitter = "\t") {

        List<string[]> results = MyUtils.ParseTextToSplitList(resource_name, splitter);
        string characters = results[0][0];
        characters = Regex.Replace(characters, "<.*?>", "");

        // test print
        string pinjing = results[0][2];
        string meaning = results[0][3];
        Debug.Log(characters + ", " + pinjing + ", " + meaning);

        return results;
    }
}
