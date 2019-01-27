using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCharacter : MonoBehaviour
{

    public string display_char;
    private Text my_text;
    private int count;
    private int most_abund_count;
    private Color base_color;

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

    public void SetCount(int count, int most_abund_count) {
        this.count = count;
        this.most_abund_count = most_abund_count;

        float frac_size = (float)count / (float)most_abund_count;
        this.base_color = new Color(1 - frac_size, 1, 1);
        background.SetColor(base_color);
    }

    public void SetMostAbundantCount() {
        
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
            background.SetColor(base_color);
        }
        menu_controller.UpdateSelected();
    }
}
