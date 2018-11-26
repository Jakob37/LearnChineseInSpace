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

    private ColorBlock theColor;

    private void SetBackgroundActive(bool active) {
        if (active) {
            background.color = new Color(background.color.r, background.color.g, background.color.b, 1);
        }
        else {
            background.color = new Color(background.color.r, background.color.g, background.color.b, 0);
        }
    }

    void Awake() {

        theColor.highlightedColor = Color.blue;
        theColor.normalColor = Color.cyan;
        theColor.pressedColor = Color.green;

        background.color = new Color(background.color.r, background.color.g, background.color.b, 0);
        // button.colors = theColor;
//        print("Cliked");
    }

    void Start() {

        SetBackgroundActive(false);
    }

    private void ColorButtonGreen() {

        button.colors = new ColorBlock();
    }

    public void Setup(GridScript parent_grid, string text, int font_size) {
        this.parent_grid = parent_grid;
        this.label.text = text;
        this.label.fontSize = font_size;
    }

    public void ButtonActivated() {
        parent_grid.ChildActivated(this);
        print("Clicked: " + this.label.text);
        SetBackgroundActive(true);
    }
}
