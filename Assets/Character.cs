using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{

    private string my_text;
    private CurrCharText curr_char_text;

    void Start() {
        my_text = GetComponentInChildren<Text>().text;
        curr_char_text = FindObjectOfType<CurrCharText>();

        print("Activated");
    }

    void OnMouseOver() {
        print("Object clicked: " + my_text);
    }
}
