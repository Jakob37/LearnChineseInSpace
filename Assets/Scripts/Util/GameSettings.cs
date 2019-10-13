using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {

    private int total_words;
    public int TotalWords {
        get { return total_words; }
        set {
            total_words = value;
            print("Assigned: " + value);
        }
    }
    
    private List<string> selected_characters;
    public List<string> SelectedCharacters {
        get { return selected_characters; }
        set {
            selected_characters = value;
        }
    }

    // private List<int> selected_chapters;
    // public List<int> SelectedChapters {
    //     get { return selected_chapters; }
    //     set { selected_chapters = value; }
    // }

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}