using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceGrid : MonoBehaviour
{

    public GameObject choice_object;
    private List<Choice> choices;
    private CharacterManager character_manager;

    public int debug_count;

    public List<string> letters;

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

        // int lacking = debug_count - NbrChoices;
        // print(lacking);

        List<string> choices = character_manager.GetChoices(ChoiceType.Meaning, 4);

        foreach (string choice in choices) {
            print(choice);
            AddChoice(choice);
        }

        // for (var i = 0; i < lacking; i++) {
        //     AddChoice();
        // }
    }

    void Update() {
        
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

        string key = letters[NbrChoices];

        choice.SetKey(key);
    }
}
