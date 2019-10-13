using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    private GameSettings game_settings;
    private ChaptersSelector chapter_selector;
    private CharacterManager char_manager;

    private GameMode game_mode;

    void Awake() {
        game_settings = FindObjectOfType<GameSettings>();
        chapter_selector = FindObjectOfType<ChaptersSelector>();
        game_mode = FindObjectOfType<GameMode>();
        char_manager = FindObjectOfType<CharacterManager>();
    }

    public void StartGame() {

        // char_manager.SyncCharacters();

        // if (game_mode.CurrentDisplay == "Chapters") {
        //     LoadChapterSettings();
        // }
        // else if (game_mode.CurrentDisplay == "Random") {
        //     LoadAnki();
        // }
        // else {
        //     throw new System.Exception("Unsupported display, nothing loaded! Display: " + game_mode.CurrentDisplay);
        // }
        LoadCharacters.UpdateTargetCharacters(LoadMode.anki);
        print("Starting with character count: " + LoadCharacters.TargetCharacters.Count);

        SceneManager.LoadScene("2_setup");
    }

    // private void LoadChapterSettings() {
    //     game_settings.SelectedCharacters = char_manager.GetChineseCharacters;
    //     // game_settings.SelectedChapters = chapter_selector.GetChapters();
    // }
    // 
    // private void LoadAnki() {
    //     print("Anki loaded");
    //     game_settings.SelectedCharacters = char_manager.GetChineseCharacters;
    // }
}
