using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceGrid : MonoBehaviour
{

    public GameObject choice_object;
    private List<Choice> choices;

    public int debug_count;

    public List<string> letters;

    private int NbrChoices {
        get {
            return GetComponentsInChildren<Choice>().Length;
        }
    }

    void Awake() {
        choices = new List<Choice>();
    }

    void Start() {

        int lacking = debug_count - NbrChoices;
        print(lacking);

        for (var i = 0; i < lacking; i++) {
            AddChoice();
        }

        //while (NbrChoices < debug_count) {
        //    AddChoice();
        //}
    }

    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            AddChoice();
        }
    }

    private void AddChoice() {
        GameObject instance = Instantiate(choice_object);
        instance.transform.SetParent(gameObject.transform);
        instance.transform.localScale = new Vector2(200, 100);
        Choice choice = instance.GetComponent<Choice>();
        choice.SetDescription("TEXT");

        string key = letters[NbrChoices];

        choice.SetKey(key);
    }
}
