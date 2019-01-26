using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChineseEntry {

    public string character;
    public string pinying;
    public string english;
    public string radical;

    public int english_correct_guesses;
    public int english_incorrect_guesses;
    public int pinyin_correct_guesses;
    public int pinyin_incorrect_guesses;

    public ChineseEntry(string character, string pinying, string english, string radical = null) {
        this.character = character;
        this.pinying = pinying;
        this.english = english;
        this.radical = radical;
    }

    public void AddGuessEnglish(bool correct) {
        if (correct) {
            english_correct_guesses++;
        }
        else {
            english_incorrect_guesses++;
        }
    }

    public void AddGuessPinyin(bool correct) {
        if (correct) {
            pinyin_correct_guesses++;
        }
        else {
            pinyin_incorrect_guesses++;
        }
    }

    public int GetTotalScore() {
        return english_correct_guesses + pinyin_correct_guesses - 
            english_incorrect_guesses - pinyin_incorrect_guesses;
    }


}
