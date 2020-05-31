using Assets.ShooterScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChoiceStatus {
    Start,
    Pinyin,
    Tone,
    Done
}

public class ChoiceGrid : MonoBehaviour {

    public GameObject choice_object;
    private CharacterManager character_manager;

    public bool with_tone;

    public int debug_count;
    private List<ActionButton> buttons;

    private bool pending_switch;
    private PlayerCube player;
    private ChoiceStatus choice_status;

    public int number_choices;
    private ScoreDisplay score_display;

    public int perfect_score;
    public int part_score;

    private int curr_meaning_score;
    private int curr_pinyin_score;
    private int curr_tone_score;
    private bool has_no_errors;

    private List<String> incorrect_characters;
    public List<String> IncorrectCharacters {
        get {
            return incorrect_characters;
        }
    }

    private Choice[] Choices {
        get {
            return GetComponentsInChildren<Choice>();
        }
    }

    private int NbrChoices {
        get {
            return GetComponentsInChildren<Choice>().Length;
        }
    }

    void Awake() {
        character_manager = FindObjectOfType<CharacterManager>();
        player = FindObjectOfType<PlayerCube>();
        score_display = FindObjectOfType<ScoreDisplay>();
        incorrect_characters = new List<String>();
    }

    void Start() {

        pending_switch = false;
        buttons = SetupButtonDict();
        choice_status = ChoiceStatus.Start;

        ClearChoices();
        List<ShooterCharacter> choices = character_manager.GetChoices(number_choices, set_new_character:true);
        foreach (ShooterCharacter choice in choices) {
            AddChoice(choice, choice_status);
        }

        SetupNewCharacter();
    }

    private List<ActionButton> SetupButtonDict() {
        var button_list = new List<ActionButton>();
        button_list.Add(new ActionButton("Z", KeyCode.Z));
        button_list.Add(new ActionButton("X", KeyCode.X));
        button_list.Add(new ActionButton("C", KeyCode.C));
        button_list.Add(new ActionButton("V", KeyCode.V));
        button_list.Add(new ActionButton("B", KeyCode.B));
        button_list.Add(new ActionButton("A", KeyCode.A));
        button_list.Add(new ActionButton("S", KeyCode.S));
        button_list.Add(new ActionButton("D", KeyCode.D));

        return button_list;
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Return)) {
            AddChoice(new ShooterCharacter("空", "placeholder", "pinyin", "-1", -1), choice_status);
        }

        for (var i = 0; i < NbrChoices; i++) {

            var button = buttons[i];
            if (Input.GetKeyDown(button.KeyCode)) {

                if ((choice_status != ChoiceStatus.Tone && Choices[i].Character.StrChar == character_manager.CurrChar) ||
                    (choice_status == ChoiceStatus.Tone && Choices[i].Character.Tone == character_manager.CurrTone)) {
                    Choices[i].TrigCorrect();
                    choice_status = IterateChoiceStatus(choice_status, with_tone);

                    TrigCorrectChoice(Choices[i].Character, choice_status);
                    if (choice_status == ChoiceStatus.Start) {
                        SetupNewCharacter();
                    }
                }
                else {
                    incorrect_characters.Add(character_manager.CurrChar);
                    Choices[i].TrigIncorrect();
                    //score_display.increment_score(-2);
                    DecreaseScore(choice_status);
                }
            }
        }
    }

    private void DecreaseScore(ChoiceStatus choice_status) {
        print("Descrease score triggered");
        has_no_errors = false;
        if (choice_status == ChoiceStatus.Start) {
            if (curr_meaning_score > 0) curr_meaning_score -= 1;
            print("meaning: " + curr_meaning_score);
        }
        else if (choice_status == ChoiceStatus.Pinyin) {
            if (curr_pinyin_score > 0) curr_pinyin_score -= 1;
            print("pinyin: " + curr_pinyin_score);
        }
        else if (choice_status == ChoiceStatus.Tone) {
            if (curr_tone_score > 0) curr_tone_score -= 1;
            print("tone: " + curr_tone_score);
        }
        else {
            throw new Exception("Unsupported status: " + choice_status);
        }
    }

    private void SetupNewCharacter() {
        curr_meaning_score = part_score;
        curr_pinyin_score = part_score;
        curr_tone_score = part_score;
        has_no_errors = true;
    }

    private void TrigCorrectChoice(ShooterCharacter correct_char, ChoiceStatus choice_status) {

        ClearChoices();
        bool new_character = choice_status == ChoiceStatus.Start;
        List<ShooterCharacter> choices;
        if (choice_status != ChoiceStatus.Tone) {
            choices = character_manager.GetChoices(number_choices, new_character);
        }
        else {
            choices = character_manager.GetToneChoices();
        }

        if (new_character) {
            player.TrigCorrectEvent(correct_char, CalculateScore());
        }

        foreach (ShooterCharacter choice in choices) {
            AddChoice(choice, choice_status);
        }
    }

    private int CalculateScore() {
        int score = curr_meaning_score + curr_pinyin_score + curr_tone_score;
        if (has_no_errors) {
            score += perfect_score;
        }
        return score;
    }

    private ChoiceStatus IterateChoiceStatus(ChoiceStatus choice_status, bool with_tone=false) {
        if (choice_status == ChoiceStatus.Start) {
            return ChoiceStatus.Pinyin;
        }
        else if (choice_status == ChoiceStatus.Pinyin && with_tone) {
            return ChoiceStatus.Tone;
        }
        else {
            return ChoiceStatus.Start;
        }
    }

    private void ClearChoices() {
        foreach (Choice choices in GetComponentsInChildren<Choice>()) {
            DestroyImmediate(choices.gameObject);
        }
    }

    private void AddChoice(ShooterCharacter character, ChoiceStatus choice_status) {
        GameObject instance = Instantiate(choice_object);
        instance.transform.SetParent(gameObject.transform);
        instance.transform.localScale = new Vector2(200, 100);

        Choice choice = instance.GetComponent<Choice>();
        choice.SetShooterCharacter(character, choice_status);
        string key = buttons[NbrChoices-1].KeyString;
        choice.SetKey(key);
    }
}
