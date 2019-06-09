using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private int score;
    private Text text;

    void Awake() {
        text = GetComponent<Text>();
        text.text = "Score: " + score;
    }

    public void increment_score(int amount) {
        score += amount;
        text.text = "Score: " + score;
    }
}
