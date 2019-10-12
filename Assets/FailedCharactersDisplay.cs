using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedCharactersDisplay : MonoBehaviour
{
    public GameObject template_object;

    void Start() {
        print("Score: " + PlayerStats.score);
        if (PlayerStats.incorr_chars != null) {
            foreach (string character in PlayerStats.incorr_chars) {
                print("You missed on: " + character);
                CreateEntry(character);
            }
        }

        CreateEntry("test1");
        CreateEntry("test2");
    }

    private void CreateEntry(string text) {
        GameObject instance = Instantiate(template_object);
        instance.transform.SetParent(gameObject.transform);
        FailedCharacterEntry menu_char = instance.GetComponent<FailedCharacterEntry>();
        menu_char.SetText(text);
        // menu_char.SetRadical(key);
        // menu_char.SetCount(radical_dict[key], largest_count);
        // menu_char.SetMostAbundantCount(largest_count);
    }

    void Update() {
        
    }
}
