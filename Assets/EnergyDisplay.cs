using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDisplay : MonoBehaviour
{
    private Text text;

    void Awake() {
        text = GetComponent<Text>();
    }

    public void SetEnergy(int energy) {
        text.text = "Energy: " + energy;
    }
}
