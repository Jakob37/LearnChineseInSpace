using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrCharText : MonoBehaviour
{

    private Text my_text;

    void Awake() {
        my_text = GetComponent<Text>();
    }

    public void SetText(string new_text) {
        my_text.text = new_text;
    }

}
