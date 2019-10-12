using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailedCharacterEntry : MonoBehaviour
{
    public bool destroy_on_load;

    private string display_text;
    private Text text;

    void Awake() {
        text = GetComponent<Text>();
    }

    public void SetText(string new_string) {
        display_text = new_string;
        this.text.text = new_string;
    }
}
