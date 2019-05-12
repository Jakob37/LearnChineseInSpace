using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    private ChoiceDescription choice_description;
    private ChoiceKey choice_key;

    void Awake() {
        choice_description = GetComponentInChildren<ChoiceDescription>();
        choice_key = GetComponentInChildren<ChoiceKey>();
    }

    public void SetKey() {

    }

    public void SetDescription(string descr) {
        choice_description.GetComponent<Text>().text = descr;
    }

    public void SetKey(string key) {
        choice_key.GetComponent<Text>().text = key;
    }
}
