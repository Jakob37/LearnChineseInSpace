using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectedCharactersStartButton : MonoBehaviour {

    // private GameSettings game_settings;

    void Start() {
        // game_settings = FindObjectOfType<GameSettings>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {

            SceneManager.LoadScene("3_scroller");
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("3_scroller");
    }
}
