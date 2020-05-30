using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    private GameObject chapter_selector_object;
    private GameObject random_toggles_object;

    private ToggleGroup toggle_group;
    private Toggle[] toggles;

    private string current_display;
    public string CurrentDisplay {
        get {
            return current_display;
        }
    }

    void Awake() {
        toggle_group = GetComponentInChildren<ToggleGroup>();
        toggles = GetComponentsInChildren<Toggle>();
        chapter_selector_object = GetComponentInChildren<ChaptersSelector>().gameObject;
        random_toggles_object = GetComponentInChildren<RandomToggles>().gameObject;
    }

    void Start() {
        current_display = GetActiveToggleName();
        SwitchDisplay(current_display);
    }

    void Update() {
        string active_toggle = GetActiveToggleName();
        if (active_toggle != current_display) {
            SwitchDisplay(active_toggle);
            current_display = active_toggle;
        }
    }

    private string GetActiveToggleName() {
        foreach (Toggle toggle in toggles) {
            if (toggle.isOn) {
                return(toggle.GetComponent<GameModeToggle>().GetName());
            }
        }
        throw new System.Exception("No active toggle found!");
    }

    private void SwitchDisplay(string target_display) {
        if (target_display == "Chapters") {
            chapter_selector_object.SetActive(true);
            random_toggles_object.SetActive(false);
        }
        else if (target_display == "Random") {
            chapter_selector_object.SetActive(false);
            random_toggles_object.SetActive(true);
        }
        else if (target_display == "AnkiFails") {
            chapter_selector_object.SetActive(false);
            random_toggles_object.SetActive(false);
        }
        else {
            chapter_selector_object.SetActive(false);
            random_toggles_object.SetActive(false);
        }
    }
}
