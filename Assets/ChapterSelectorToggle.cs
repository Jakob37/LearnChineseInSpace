using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterSelectorToggle : MonoBehaviour
{
    private Toggle toggle;

    private int chapter;
    public int Chapter {
        get {
            return chapter;
        }
    }

    private Text my_text;
    public bool destroy_on_start;

    void Awake() {
        my_text = GetComponentInChildren<Text>();
        toggle = GetComponent<Toggle>();
        if (destroy_on_start) {
            DestroyImmediate(gameObject);
        }
    }

    public void AssignChapter(int chapter) {
        this.chapter = chapter;
        my_text.text = "Chapter " + chapter;
    }

    public bool IsToggled() {
        return toggle.isOn;
    }
}
