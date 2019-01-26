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

    // public SpriteRenderer my_renderer;

    private Text my_text_obj;
    private CurrCharText curr_char_text;
    private Transform my_transform;
    private EventControllerMain event_controller;
    private MyCharacters my_characters;
    private CharacterType char_type;
    private CharacterBackground background;

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
        // my_renderer = GetComponentInChildren<SpriteRenderer>();
        // print("My renderer: " + my_renderer);
    }

    public void Initialize(CharacterType char_type) {
        var entry = my_characters.RequestEntry();
        chinese_character = entry.character;
        english_meaning = entry.english;
        pinyin = entry.pinying;
        my_text_obj.text = chinese_character;
        this.char_type = char_type;
        // chinese_character = "书";


        if (this.char_type == CharacterType.English) {
            print("Assigning color");
            background.SetColor(new Color(1, 0.9f, 0.9f));
        }
        else {
            background.SetColor(new Color(0.9f, 1, 0.9f));
        }
    }

    void Start() {

        my_text_obj.text = chinese_character;
        print("Activated");
    }

    public void Step() {
        my_transform.position = new Vector2(my_transform.position.x, my_transform.position.y - step_length);
    }

    void OnMouseDown() {
        print("Object clicked: " + chinese_character);
        if (char_type == CharacterType.English) {
            curr_char_text.SetText(chinese_character + " (" + pinyin + ")");
        }
        else {
            curr_char_text.SetText(chinese_character + " (" + english_meaning + ")");
        }
        event_controller.CharacterTriggered(this);
    }


}
