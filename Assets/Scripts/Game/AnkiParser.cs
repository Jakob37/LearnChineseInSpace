using Assets.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;


public static class AnkiParser {


    private static List<String[]> word_entries;
    private static List<ChineseEntry> chinese_entries;

    public static List<ChineseEntry> ParseChineseEntries() {
        word_entries = new List<String[]>();
        word_entries = ParseStoryEntities("glossary");

        chinese_entries = new List<ChineseEntry>();
        foreach (String[] word_entry in word_entries) {

            String raw_chinese_char = word_entry[1];
            String raw_pinying = word_entry[2];
            String raw_english = word_entry[3];

            String parsed_chinese_char = Regex.Replace(raw_chinese_char, "<.*?>", "");
            String parsed_english = Regex.Replace(Regex.Replace(raw_english, "•.*", ""), "<CC>", "");
            ChineseEntry entry = new ChineseEntry(parsed_chinese_char, raw_pinying, parsed_english);
            chinese_entries.Add(entry);

        }
        return chinese_entries;
    }

    // public static string GetChineseWord(int number=0) {
    // 
    //     if (number < chinese_characters.Count) {
    //         return chinese_characters[number];
    //     }
    //     else {
    //         return "-";
    //     }
    // }
    // 
    // public static string GetPingyingWord(int number = 0) {
    // 
    //     if (number < pinying.Count) {
    //         return pinying[number];
    //     }
    //     else {
    //         return "-";
    //     }
    // }
    // 
    // public static string GetEnglishWord(int number = 0) {
    // 
    //     if (number < english.Count) {
    //         return english[number];
    //     }
    //     else {
    //         return "-";
    //     }
    // }

    private static List<String[]> ParseStoryEntities(string resource_name, string splitter = "\t") {

        List<string[]> results = Utils.ParseTextToSplitList(resource_name, splitter);
        string characters = results[0][0];
        characters = Regex.Replace(characters, "<.*?>", "");

        // test print
        string pinjing = results[0][2];
        string meaning = results[0][3];
        Debug.Log(characters + ", " + pinjing + ", " + meaning);

        return results;
    }
}
