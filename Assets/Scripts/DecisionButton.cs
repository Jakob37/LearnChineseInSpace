using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionButton : MonoBehaviour
{

    private Text text_object;

    void Awake() {
        text_object = GetComponentInChildren<Text>();
    }

    public void SetText(string text) {
        text_object.text = text;
    }

    public string GetText() {
        return text_object.text;
    }
}
