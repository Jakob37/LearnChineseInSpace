using Assets.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;


public class AnkiParser : MonoBehaviour {


    private List<String[]> word_entries;
    private List<String> chinese_characters;
    private List<String> pinying;
    private List<String> english;

    void Awake() {
        word_entries = new List<String[]>();
        word_entries = ParseStoryEntities("glossary");

        chinese_characters = new List<String>();
        pinying = new List<String>();
        english = new List<String>();
        foreach (String[] word_entry in word_entries) {

            String raw_chinese_char = word_entry[0];
            String raw_pinying = word_entry[2];
            String raw_english = word_entry[3];

            String parsed_chinese_char = Regex.Replace(raw_chinese_char, "<.*?>", "");
            chinese_characters.Add(parsed_chinese_char);

            String parsed_english = Regex.Replace(raw_english, "•.*", "");
            parsed_english = Regex.Replace(parsed_english, "<CC>", "");

            pinying.Add(raw_pinying);
            english.Add(parsed_english);
        }
    }

    void Start() {

    }

    public string GetChineseWord(int number=0) {

        if (number < chinese_characters.Count) {
            return chinese_characters[number];
        }
        else {
            return "-";
        }
    }

    public string GetPingyingWord(int number = 0) {

        if (number < pinying.Count) {
            return pinying[number];
        }
        else {
            return "-";
        }
    }

    public string GetEnglishWord(int number = 0) {

        if (number < english.Count) {
            return english[number];
        }
        else {
            return "-";
        }
    }

    private List<String[]> ParseStoryEntities(string resource_name, string splitter = "\t") {

        List<string[]> results = Utils.ParseTextToSplitList(resource_name, splitter);
        string characters = results[0][0];
        characters = Regex.Replace(characters, "<.*?>", "");

        // test print
        string pinjing = results[0][2];
        string meaning = results[0][3];
        print(characters + ", " + pinjing + ", " + meaning);

        return results;
    }


}
