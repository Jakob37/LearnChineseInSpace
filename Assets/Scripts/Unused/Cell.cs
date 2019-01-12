using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour {

    public Image mOutlineImage;

    public Vector2Int mBoardPosition = Vector2Int.zero;
    public RectTransform mRectTransform = null;

    private GridScript parent_grid;
    public Text label;
    public Button button;
    public Image background;

    private ChineseEntry chinese_entry;
    public ChineseEntry ChineseEntry { get { return chinese_entry; } }

    private ColorBlock theColor;

    private void SetBackgroundActive(bool active) {
        if (active) {
            background.color = Color.green;
        }
        else {
            background.color = Color.white;
        }
    }

    void Awake() {

        theColor.highlightedColor = Color.blue;
        theColor.normalColor = Color.cyan;
        theColor.pressedColor = Color.green;

        background.color = Color.white;
        // button.colors = theColor;
//        print("Cliked");
    }

    void Start() {

        SetBackgroundActive(false);
    }

    private void ColorButtonGreen() {

        button.colors = new ColorBlock();
    }

    public void Setup(GridScript parent_grid, ChineseEntry entry, GridLanguage cell_type, int font_size) {

        this.parent_grid = parent_grid;
        this.chinese_entry = entry;
        string new_word = "";

        switch (cell_type) {
            case GridLanguage.character:
                new_word = entry.character;
                break;
            case GridLanguage.pinying:
                new_word = entry.pinying;
                break;
            case GridLanguage.english:
                new_word = entry.english;
                break;
            default:
                throw new KeyNotFoundException("Unknown GridLanguage case encountered: " + cell_type);
        }

        float font_scale = 1;
        if (new_word.Length > 30) {
            font_scale = 0.7f;
        }

        this.label.text = new_word;
        this.label.fontSize = (int)(font_size * font_scale);
    }

    public void GridCellActivated(Cell cell) {
        if (cell == this) {
            return;
        }
        else {
            SetBackgroundActive(false);
        }
    }

    public void ButtonActivated() {
        parent_grid.ChildActivated(this);
        // print("Clicked: " + this.label.text);
        SetBackgroundActive(true);
    }
}
