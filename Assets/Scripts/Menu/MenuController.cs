using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public string text_source;

    private TextLoader text_loader;
    // private MyCharacters my_chars;
    private GameSettings game_settings;
    private MenuStatusText menu_status_text;

    private Dictionary<string, int> radicals;
    public Dictionary<string, int> RadicalDict {
        get {
            return radicals;
        }
    }
    private List<string> selected_radicals;

    void Awake() {
        text_loader = FindObjectOfType<TextLoader>();
        game_settings = FindObjectOfType<GameSettings>();
        menu_status_text = FindObjectOfType<MenuStatusText>();
    }

    public void UpdateSelected() {
        selected_radicals = new List<string>();
        MenuCharacter[] all_chars = FindObjectsOfType<MenuCharacter>();
        foreach (MenuCharacter menu_char in all_chars) {
            if (menu_char.IsSelected) {
                selected_radicals.Add(menu_char.Text);
            }
        }
        game_settings.SelectedCharacters = selected_radicals;
        int total_words = GetNumberWords(selected_radicals);
        menu_status_text.SetCount(total_words);
    }

    private int GetNumberWords(List<string> selected_radicals) {
        int total_words = 0;
        foreach (string radical in selected_radicals) {
            total_words += radicals[radical];
        }
        return total_words;
    }

    void Start() {
        List<ChineseEntry> entries = text_loader.ParseChineseEntries(text_source);
        radicals = new Dictionary<string, int>();
        foreach (ChineseEntry entry in entries) {
            if (!radicals.ContainsKey(entry.radical)) {
                radicals.Add(entry.radical, 0);
            }
            radicals[entry.radical] += 1;
        }
    }
}
