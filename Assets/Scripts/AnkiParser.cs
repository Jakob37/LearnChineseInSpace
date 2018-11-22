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

    void Awake() {
        word_entries = new List<String[]>();
        word_entries = ParseStoryEntities("glossary");

        chinese_characters = new List<String>();
        foreach(String[] word_entry in word_entries) {
            String raw_chinese_char = word_entry[0];
            String parsed_chinese_char = Regex.Replace(raw_chinese_char, "<.*?>", "");
            chinese_characters.Add(parsed_chinese_char);
        }
    }

    void Start() {

    }

    public string GetWord(int number=0) {

        if (number < chinese_characters.Count) {
            return chinese_characters[number];
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
