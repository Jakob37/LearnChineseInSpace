using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStatusText : MonoBehaviour
{

    private Text my_text;

    void Awake() {
        my_text = GetComponent<Text>();
    }

    public void SetCount(int selected) {
        my_text.text = "Selected: " + selected;
    }
}
