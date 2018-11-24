using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GridLanguage {
    character,
    pinying,
    english
}

public class GridScript : MonoBehaviour {

    public GameObject mCellPrefab;
    public int cells;

    public GridLanguage cell_type;

    private Cell[] mCells = new Cell[1000];
    private AnkiParser anki_parser;

    public int font_size;

    void Awake() {
        anki_parser = GameObject.FindObjectOfType<AnkiParser>();
    }

    void Start() {
        Build();
    }

    public void Build() {
        for (int i = 0; i < cells; i++) {
            GameObject newCell = Instantiate(mCellPrefab, transform);
            mCells[i] = newCell.GetComponent<Cell>();

            string new_word = "";
            if (cell_type == GridLanguage.character) {
                new_word = anki_parser.GetChineseWord(i);
            }
            else if (cell_type == GridLanguage.pinying) {
                new_word = anki_parser.GetPingyingWord(i);
            }
            else if (cell_type == GridLanguage.english) {
                new_word = anki_parser.GetEnglishWord(i);
            }
            else {
                print("Unknown type");
            }

            float font_scale = 1;
            if (new_word.Length > 30) {
                font_scale = 0.7f;
            }

            mCells[i].Setup(new_word, (int)(font_size * font_scale));
        }
    }
}