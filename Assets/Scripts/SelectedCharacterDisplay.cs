using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedCharacterDisplay : MonoBehaviour {

    private Text display_text;
    private ShooterCharacter character;

    public bool is_display_object;

    void Awake() {
        display_text = GetComponent<Text>();
        if (is_display_object) {
            print("Cleaning up placeholder SelectedCharacterDisplay object");
            DestroyImmediate(gameObject);
        }
    }

    public void AssignCharacter(ShooterCharacter character) {
        this.character = character;
        display_text.text = character.AsString;
    }
}
