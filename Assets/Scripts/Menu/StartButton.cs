using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    private GameSettings game_settings;
    private ChaptersSelector chapter_selector;
    private CharacterManager char_manager;
    private RandomToggles random_toggles;

    private GameMode game_mode;

    void Awake() {
        game_settings = FindObjectOfType<GameSettings>();
        chapter_selector = FindObjectOfType<ChaptersSelector>();
        game_mode = FindObjectOfType<GameMode>();
        char_manager = FindObjectOfType<CharacterManager>();
        random_toggles = FindObjectOfType<RandomToggles>();
    }

    public void StartGame() {

        LoadCharacters.UpdateTargetCharacters(LoadMode.anki, anki_count:random_toggles.GetSelectedCount());
        print("Starting with character count: " + LoadCharacters.TargetCharacters.Count);

        SceneManager.LoadScene("2_setup");
    }
}
