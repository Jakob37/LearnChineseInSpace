using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaptersSelector : MonoBehaviour
{
    public int chapters;
    public GameObject selector;

    void Start() {
        
        for (var i = 0; i < chapters; i++) {
            AddChapter(i + 1);
        }
    }

    private void AddChapter(int chapter_nbr) {
        var obj = Instantiate(selector, gameObject.transform);
        ChapterSelectorToggle toggle_script = obj.GetComponentInChildren<ChapterSelectorToggle>();
        toggle_script.AssignChapter(chapter_nbr);
    }

    public List<int> GetChapters() {
        List<int> selected_chapters = new List<int>();
        ChapterSelectorToggle[] all_toggles = GetComponentsInChildren<ChapterSelectorToggle>();
        foreach (ChapterSelectorToggle toggle in all_toggles) {
            if (toggle.IsToggled()) {
                selected_chapters.Add(toggle.Chapter);
            }
        }
        return selected_chapters;
    }
}
