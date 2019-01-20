using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{

    private Text my_text_obj;
    private CurrCharText curr_char_text;
    public string chinese_character;
    public string english_meaning;
    public string pinjing;
    public string tone;

    private EventControllerMain event_controller;

    public ChineseEntry ChineseEntry {
        get {
            return new ChineseEntry(this.chinese_character, this.pinjing, this.english_meaning);
        }
    }

    void Awake() {
        my_text_obj = GetComponentInChildren<Text>();
        curr_char_text = FindObjectOfType<CurrCharText>();
        event_controller = FindObjectOfType<EventControllerMain>();
    }

    void Start() {

        my_text_obj.text = chinese_character;
        print("Activated");
    }

    void OnMouseDown() {
        print("Object clicked: " + chinese_character);
        curr_char_text.SetText(chinese_character + " (" + pinjing + ")");
        event_controller.CharacterTriggered(this);
    }


}
