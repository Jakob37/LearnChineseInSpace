using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text text;

    void Awake() {
        text = GetComponent<Text>();
    }

    public void SetScore(int score) {
        text.text = "Score: " + score;
    }
}
