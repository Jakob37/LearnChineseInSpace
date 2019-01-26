using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public string text_source;

    private TextLoader text_loader;
    private MyCharacters my_chars;

    void Awake() {
        text_loader = FindObjectOfType<TextLoader>();

    }

    void Start() {
        List<ChineseEntry> entries = text_loader.ParseChineseEntries(text_source);
        Dictionary<string, int> radicals = new Dictionary<string, int>();
        foreach (ChineseEntry entry in entries) {
            if (!radicals.ContainsKey(entry.radical)) {
                radicals.Add(entry.radical, 0);
            }
            radicals[entry.radical] += 1;
        }

        foreach (string radical in radicals.Keys) {
            print(radical + ": " + radicals[radical]);
        }
    }

}
