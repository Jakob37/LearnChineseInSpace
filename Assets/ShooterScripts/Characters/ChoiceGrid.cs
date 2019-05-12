using Assets.ShooterScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ChoiceGrid : MonoBehaviour
{

    public GameObject choice_object;
    private List<Choice> choices;
    private CharacterManager character_manager;

    public int debug_count;
    private List<ActionButton> buttons;

    private int NbrChoices {
        get {
            return GetComponentsInChildren<Choice>().Length;
        }
    }

    void Awake() {
        choices = new List<Choice>();
        character_manager = GetComponent<CharacterManager>();
    }

    void Start() {

        buttons = SetupButtonDict();
        List<string> choices = character_manager.GetChoices(ChoiceType.Meaning, 4);

        foreach (string choice in choices) {
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

        print(NbrChoices);
        if (Input.GetKeyDown(KeyCode.Return)) {
            AddChoice();
        }
    }

    private void AddChoice(string text="Text") {
        GameObject instance = Instantiate(choice_object);
        instance.transform.SetParent(gameObject.transform);
        instance.transform.localScale = new Vector2(200, 100);
        Choice choice = instance.GetComponent<Choice>();
        choice.SetDescription(text);

        //string key = letters[NbrChoices];
        print("Index: " + NbrChoices);
        string key = buttons[NbrChoices-1].KeyString;
        print(key);

        choice.SetKey(key);
    }
}
