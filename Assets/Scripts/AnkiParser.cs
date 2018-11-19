using Assets.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;


public class AnkiParser : MonoBehaviour {

    void Start() {

        print("I am testing");
        ParseStoryEntities("glossary");
    }

    private void ParseStoryEntities(string resource_name, string splitter = "\t") {
    //private Dictionary<StoryBoardEntity, List<string>> ParseStoryEntities(string resource_name, string splitter = "\\|") {

        //Dictionary<StoryBoardEntity, List<string>> board_entities_tmp = new Dictionary<StoryBoardEntity, List<string>>();

        List<string[]> results = Utils.ParseTextToSplitList(resource_name, splitter);
        print(results);

        //for (int pos = 0; pos < results[0].Length; pos++) {
        //    print(results[0][pos]);
        //}

        string characters = results[0][0];

        characters = Regex.Replace(characters, "<.*?>", "");

        string pinjing = results[0][2];
        string meaning = results[0][3];

        print(characters + ", " + pinjing + ", " + meaning);

        //print(results[0][0]);
        //foreach (string[] board_entry in board_entries) {

        //    if (board_entry[0] == "" || board_entry[0].Substring(0, 1) == "#") {
        //        continue;
        //    }

        //    if (board_entry[1] == "name") {
        //        continue;
        //    }

        //    string board_text = board_entry[1];
        //    if (!board_entities_tmp.ContainsKey(board_name)) {
        //        board_entities_tmp[board_name] = new List<String>();
        //    }

        //    board_entities_tmp[board_name].Add(board_text);
        //}

        //return board_entities_tmp;
    }


}
