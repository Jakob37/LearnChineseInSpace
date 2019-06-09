using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private Text text;

    void Awake() {
        text = GetComponent<Text>();
    }

    public void SetHealth(int health) {
        text.text = "Health: " + health;
    }
}
