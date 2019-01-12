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

    void Awake() {
        my_text_obj = GetComponentInChildren<Text>();
        curr_char_text = FindObjectOfType<CurrCharText>();
    }

    void Start() {

        my_text_obj.text = chinese_character;
        print("Activated");
    }

    void OnMouseDown() {
        print("Object clicked: " + chinese_character);
        curr_char_text.SetText("Assigned text: " + chinese_character);
    }
}
