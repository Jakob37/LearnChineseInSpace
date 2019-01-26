using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterType {
    English,
    Pinying
}

public class Character : MonoBehaviour
{

    public string chinese_character;
    public string english_meaning;
    public string pinyin;
    public string tone;
    public float step_length;
    public CharacterType CharType {
        get {
            return char_type;
        }
    }

    // public SpriteRenderer my_renderer;

    private int inactive_ticks;
    private Text my_text_obj;
    private CurrCharText curr_char_text;
    private Transform my_transform;
    private EventControllerMain event_controller;
    private MyCharacters my_characters;
    private CharacterType char_type;
    private CharacterBackground background;
    private const int penalty_ticks = 3;

    private Color inactive_color = new Color(0.8f, 0.8f, 0.8f);
    private Color english_color = new Color(1, 0.9f, 0.9f);
    private Color pinyin_color = new Color(0.9f, 1, 0.9f);

    public ChineseEntry ChineseEntry {
        get {
            return new ChineseEntry(this.chinese_character, this.pinyin, this.english_meaning);
        }
    }

    void Awake() {
        my_text_obj = GetComponentInChildren<Text>();
        curr_char_text = FindObjectOfType<CurrCharText>();
        event_controller = FindObjectOfType<EventControllerMain>();
        my_transform = gameObject.transform;
        my_characters = FindObjectOfType<MyCharacters>();
        background = GetComponentInChildren<CharacterBackground>();
    }

    public void Initialize(CharacterType char_type) {
        var entry = my_characters.RequestEntry();
        chinese_character = entry.character;
        english_meaning = entry.english;
        pinyin = entry.pinying;
        my_text_obj.text = chinese_character;
        this.char_type = char_type;
        // chinese_character = "书";
        AssignColor();
    }

    private void AssignColor() {
        Color my_color;
        if (inactive_ticks > 0) {
            my_color = inactive_color;
        }
        else {
            if (this.char_type == CharacterType.English) {
                my_color = english_color;
            }
            else {
                my_color = pinyin_color;
            }
        }
        background.SetColor(my_color);
    }

    void Start() {
        my_text_obj.text = chinese_character;
        print("Activated");
    }

    public void Step() {
        my_transform.position = new Vector2(my_transform.position.x, my_transform.position.y - step_length);
        if (inactive_ticks > 0) {
            inactive_ticks--;
        }
        AssignColor();
    }

    public void IncorrectGuess() {
        inactive_ticks = penalty_ticks;
    }

    void OnMouseDown() {
        print("Object clicked: " + chinese_character);

        if (inactive_ticks > 0) {
            print("Inactive! Ticks left: " + inactive_ticks);
            return;
        }

        if (char_type == CharacterType.Pinying) {
            curr_char_text.SetText(chinese_character + " (" + english_meaning + ")");
        }
        else if (char_type == CharacterType.English) {
            curr_char_text.SetText(chinese_character + " (" + pinyin + ")");
        }
        else {
            throw new System.Exception("Unknown char_type: " + char_type);
        }
        event_controller.CharacterTriggered(this);
    }


}
