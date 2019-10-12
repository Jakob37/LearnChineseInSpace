using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeToggle : MonoBehaviour
{
    private Text text;
    public string GetName() {
        return text.text;
    }

    void Awake() {
        text = GetComponentInChildren<Text>();
    }
}
