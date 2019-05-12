using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentCharacterDisplay : MonoBehaviour
{
    private Text display_text;

    void Awake() {
        display_text = GetComponentInChildren<Text>();
        display_text.text = "空";
    }

    public void SetText(string text) {
        display_text.text = text;
    }
}
