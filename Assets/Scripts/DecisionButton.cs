using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionButton : MonoBehaviour
{

    private Text text_object;
    private EventControllerMain event_controller;

    void Awake() {
        text_object = GetComponentInChildren<Text>();
        event_controller = FindObjectOfType<EventControllerMain>();
    }

    public void SetText(string text) {
        text_object.text = text;
    }

    public string GetText() {
        return text_object.text;
    }

    public void ButtonClicked() {
        event_controller.DecisionButtonTriggered(this);
    }
}
