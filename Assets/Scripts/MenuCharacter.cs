using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCharacter : MonoBehaviour
{

    public string display_char;
    private Text my_text;
    private int count;
    private CharacterBackground background;

    void Awake() {
        my_text = GetComponentInChildren<Text>();
        my_text.text = display_char;
        background = GetComponentInChildren<CharacterBackground>();
    }

    public void SetRadical(string radical) {
        my_text.text = radical;
    }

    public void SetCount(int count) {
        this.count = count;
    }

    void OnMouseDown() {
        print("Clicked: " + my_text.text);
        background.SetColor(new Color(0.6f, 0, 0.6f));
    }
}
