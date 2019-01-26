using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusText : MonoBehaviour {

    private Text my_text;

    void Awake() {
        my_text = GetComponent<Text>();
    }

    public void SetText(string text) {
        my_text.text = text;
    }

}