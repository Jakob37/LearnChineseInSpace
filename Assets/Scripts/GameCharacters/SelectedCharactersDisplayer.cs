using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharactersDisplayer : MonoBehaviour
{
    public GameObject display_object;

    private CharacterManager character_manager;
    private List<ShooterCharacter> selected_characters;

    void Awake() {
    }

    void Start() {
        character_manager = FindObjectOfType<CharacterManager>();
        // print(character_manager.TargetCharacters);
        selected_characters = LoadCharacters.TargetCharacters;

        foreach (ShooterCharacter my_char in selected_characters) {
            AddDisplayedCharacter(my_char);
        }
    }

    private void AddDisplayedCharacter(ShooterCharacter character) {
        GameObject instance = Instantiate(display_object);
        instance.transform.SetParent(gameObject.transform);
        // instance.transform.localScale = new Vector2(200, 100);

        SelectedCharacterDisplay disp = instance.GetComponent<SelectedCharacterDisplay>();
        disp.AssignCharacter(character);
    }
}
