using Assets.ShooterScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChoiceStatus {
    Start,
    Pinyin,
    Tone,
    Done
}

public class ChoiceGrid : MonoBehaviour
{

    public GameObject choice_object;
    private CharacterManager character_manager;

    public int debug_count;
    private List<ActionButton> buttons;

    private bool pending_switch;
    private PlayerCube player;

    private ChoiceStatus choice_status;

    public int number_choices;

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
        character_manager = GetComponent<CharacterManager>();
        player = FindObjectOfType<PlayerCube>();
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
                    choice_status = IterateChoiceStatus(choice_status);
                    TrigCorrectChoice(Choices[i].Character, choice_status);
                }
                else {
                    Choices[i].TrigIncorrect();
                }
            }
        }
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
            player.TrigCorrectEvent(correct_char);
        }

        foreach (ShooterCharacter choice in choices) {
            AddChoice(choice, choice_status);
        }
    }

    private ChoiceStatus IterateChoiceStatus(ChoiceStatus choice_status) {
        if (choice_status == ChoiceStatus.Start) {
            return ChoiceStatus.Pinyin;
        }
        else if (choice_status == ChoiceStatus.Pinyin) {
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
