using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceKey : MonoBehaviour
{
    private string my_text;
    public string MyText {
        get {
            return my_text;
        }
    }

    void Start() {
        my_text = GetComponent<Text>().text;
    }
}
