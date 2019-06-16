using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    private GameSettings game_settings;
    private ChaptersSelector chapter_selector;

    void Awake() {
        game_settings = FindObjectOfType<GameSettings>();
        chapter_selector = FindObjectOfType<ChaptersSelector>();
    }

    public void StartGame() {
        LoadSettings();
        SceneManager.LoadScene("2_setup");
    }

    private void LoadSettings() {
        game_settings.SelectedChapters = chapter_selector.GetChapters();
    }
}
