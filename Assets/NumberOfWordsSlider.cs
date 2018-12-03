using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfWordsSlider : MonoBehaviour {

    private GameSettings game_settings;
    private Slider slider;
    private Text status_text;

    void Awake() {
        game_settings = GameObject.FindObjectOfType<GameSettings>();
        slider = gameObject.GetComponent<Slider>();
        status_text = gameObject.GetComponentInChildren<Text>();
        UpdateNumberOfWords();
    }

    public void UpdateNumberOfWords() {
        game_settings.TotalWords = (int)slider.value;
        status_text.text = "Total words: " + (int)slider.value;
    }
}
