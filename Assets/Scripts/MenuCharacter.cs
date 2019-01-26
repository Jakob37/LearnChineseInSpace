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
    private MenuController menu_controller;
    private bool is_selected;
    public bool IsSelected {
        get {
            return is_selected;
        }
    }

    public string Text {
        get {
            return my_text.text;
        }
    }

    void Awake() {
        my_text = GetComponentInChildren<Text>();
        my_text.text = display_char;
        background = GetComponentInChildren<CharacterBackground>();
        menu_controller = FindObjectOfType<MenuController>();
    }

    public void SetRadical(string radical) {
        my_text.text = radical;
    }

    public void SetCount(int count) {
        this.count = count;
    }

    void OnMouseDown() {
        print("Clicked: " + my_text.text);
        ToggleSelected();
    }

    private void ToggleSelected() {
        is_selected = !is_selected;

        if (is_selected) {
            background.SetColor(new Color(0.6f, 0, 0.6f));
        }
        else {
            background.SetColor(new Color(0, 0, 0));
        }
        menu_controller.UpdateSelected();
    }
}
