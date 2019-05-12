using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    private ChoiceDescription choice_description;
    private ChoiceKey choice_key;

    private Color start_color;

    public float color_sec;
    private float correct_remain_time;
    private float incorrect_remain_time;

    private string character;
    public string Character {
        get {
            return character;
        }
    }

    private SpriteRenderer renderer;

    public bool dev_placeholder;

    void Awake() {
        if (dev_placeholder) {
            print("Cleaning up placeholder grid object");
            Destroy(gameObject);
        }
        choice_description = GetComponentInChildren<ChoiceDescription>();
        choice_key = GetComponentInChildren<ChoiceKey>();
        renderer = GetComponent<SpriteRenderer>();

        start_color = renderer.color;
    }

    void Update() {
        if (correct_remain_time > 0) {
            DoTint(Color.green);
        }
        else if (incorrect_remain_time > 0) {
            DoTint(Color.red);
        }
        else {
            DoTint(start_color);
        }

        correct_remain_time -= Time.deltaTime;
        incorrect_remain_time -= Time.deltaTime;
    }

    private void DoTint(Color color) {
        renderer.color = color;
    }

    public void TrigCorrect() {
        print("Trig correct");
        correct_remain_time = color_sec;
        incorrect_remain_time = 0;
    }

    public void TrigIncorrect() {
        incorrect_remain_time = color_sec;
        correct_remain_time = 0;
    }

    public void SetCharacter(string character) {
        this.character = character;
    }

    public void SetDescription(string descr) {
        choice_description.GetComponent<Text>().text = descr;
    }

    public void SetKey(string key) {
        choice_key.GetComponent<Text>().text = key;
    }
}
