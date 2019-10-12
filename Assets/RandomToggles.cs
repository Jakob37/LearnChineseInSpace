using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomToggles : MonoBehaviour
{
    private Slider slider;
    private Text text;

    void Awake() {
        slider = GetComponentInChildren<Slider>();
        text = GetComponentInChildren<Text>();
    }

    void Update() {
        text.text = "Characters: " + slider.value;
    }
}
