using Assets.ShooterScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ChoiceGrid : MonoBehaviour
{

    public GameObject choice_object;
    private CharacterManager character_manager;

    public int debug_count;
    private List<ActionButton> buttons;

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
    }

    void Start() {

        buttons = SetupButtonDict();
        List<ShooterCharacter> choices = character_manager.GetChoices(4);

        // OK, we kind of need one collected object for this information

        foreach (ShooterCharacter choice in choices) {
            print(choice);
            AddChoice(choice);
        }
    }

    private List<ActionButton> SetupButtonDict() {
        var button_list = new List<ActionButton>();
        button_list.Add(new ActionButton("Z", KeyCode.Z));
        button_list.Add(new ActionButton("X", KeyCode.X));
        button_list.Add(new ActionButton("C", KeyCode.C));
        button_list.Add(new ActionButton("V", KeyCode.V));
        button_list.Add(new ActionButton("A", KeyCode.A));
        button_list.Add(new ActionButton("S", KeyCode.S));
        button_list.Add(new ActionButton("D", KeyCode.D));
        button_list.Add(new ActionButton("F", KeyCode.F));

        return button_list;
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Return)) {
            AddChoice(new ShooterCharacter("空", "placeholder", "pinyin", -1));
        }

        for (var i = 0; i < NbrChoices; i++) {
            var button = buttons[i];
            if (Input.GetKeyDown(button.KeyCode)) {
                print("Triggering for: " + Choices[i].Character + " correct is: " + character_manager.CurrChar);

                if (Choices[i].Character == character_manager.CurrChar) {
                    Choices[i].TrigCorrect();
                }
                else {
                    Choices[i].TrigIncorrect();
                }
            }
        }

        foreach (ActionButton button in buttons.GetRange(0, NbrChoices)) {

        }
    }

    private void AddChoice(ShooterCharacter character) {
        GameObject instance = Instantiate(choice_object);
        instance.transform.SetParent(gameObject.transform);
        instance.transform.localScale = new Vector2(200, 100);

        Choice choice = instance.GetComponent<Choice>();
        choice.SetDescription(character.Meaning);
        string key = buttons[NbrChoices-1].KeyString;
        choice.SetKey(key);
        choice.SetCharacter(character.StrChar);
    }
}
