using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    private ChoiceDescription choice_description;
    private ChoiceKey choice_key;

    private Collider2D collider;
    private Color start_color;

    public float color_sec;
    private float correct_remain_time;
    private float incorrect_remain_time;

    private bool has_new_click;
    public bool GetNewClick() {
        if (has_new_click) {
            has_new_click = false;
            return true;
        }
        else {
            return false;
        }
    }

    private RuntimePlatform platform;

    public bool ReadyToSwitch {
        get {
            return correct_remain_time <= 0 && incorrect_remain_time <= 0;
        }
    }

    private ShooterCharacter character;
    public ShooterCharacter Character {
        get {
            return character;
        }
    }

    private SpriteRenderer renderer;

    public bool dev_placeholder;

    void Awake() {
        choice_description = GetComponentInChildren<ChoiceDescription>();
        choice_key = GetComponentInChildren<ChoiceKey>();
        renderer = GetComponent<SpriteRenderer>();
        platform = Application.platform;
        collider = GetComponent<Collider2D>();

        start_color = renderer.color;

        if (dev_placeholder) {
            print("Cleaning up placeholder grid object");
            DestroyImmediate(gameObject);
        }
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




        if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) {
            if (Input.touchCount > 0) {
                if (Input.GetTouch(0).phase == TouchPhase.Began) {
                    checkTouch(Input.GetTouch(0).position);
                }
            }
        }
        else if (platform == RuntimePlatform.WindowsEditor) {
            if (Input.GetMouseButtonDown(0)) {
                checkTouch(Input.mousePosition);
            }
        }
    }

    private void checkTouch(Vector3 pos) {

        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        var hit = collider.bounds.Contains(touchPos);

        if (hit) {
            print(choice_key.MyText);
            has_new_click = true;
        }
    }

    private void DoTint(Color color) {
        renderer.color = color;
    }

    public void TrigCorrect() {
        correct_remain_time = color_sec;
        incorrect_remain_time = 0;
    }

    public void TrigIncorrect() {
        incorrect_remain_time = color_sec;
        correct_remain_time = 0;
    }

    public void SetShooterCharacter(ShooterCharacter character, ChoiceStatus choice_status) {
        this.character = character;

        if (choice_status == ChoiceStatus.Start) {
            this.choice_description.GetComponent<Text>().text = character.Meaning;
        }
        else if (choice_status == ChoiceStatus.Pinyin) {
            this.choice_description.GetComponent<Text>().text = character.FlatPinying;
        }
        else if (choice_status == ChoiceStatus.Tone) {
            this.choice_description.GetComponent<Text>().text = "" + character.Tone;
        }
        else {
            throw new System.Exception("Unknown choice status: " + choice_status);
        }
    }

    public void SetKey(string key) {
        choice_key.GetComponent<Text>().text = key;
    }
}
