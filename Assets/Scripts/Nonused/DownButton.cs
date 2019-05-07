using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownButton : MonoBehaviour
{
    private EventControllerMain event_controller;

    void Awake() {
        event_controller = FindObjectOfType<EventControllerMain>();
    }

    public void TrigStep() {
        event_controller.TrigStep();
    }
}
