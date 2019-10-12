using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    private GameSettings game_settings;
    private ChaptersSelector chapter_selector;

    private GameMode game_mode;

    void Awake() {
        game_settings = FindObjectOfType<GameSettings>();
        chapter_selector = FindObjectOfType<ChaptersSelector>();
        game_mode = FindObjectOfType<GameMode>();
    }

    public void StartGame() {

        if (game_mode.CurrentDisplay == "Chapters") {
            LoadChapterSettings();
        }
        else if (game_mode.CurrentDisplay == "Random") {

        }
        else {
            throw new System.Exception("Unsupported display, nothing loaded! Display: " + game_mode.CurrentDisplay);
        }
        SceneManager.LoadScene("2_setup");
    }

    private void LoadChapterSettings() {
        game_settings.SelectedChapters = chapter_selector.GetChapters();
    }
}
