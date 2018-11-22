using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour {

    public Image mOutlineImage;

    public Vector2Int mBoardPosition = Vector2Int.zero;
    public Board mBoard = null;
    public RectTransform mRectTransform = null;

    public Text mLabel;
    public Button mButton;

    void Start() {
    }

    public void Setup(string text) {
        mLabel.text = text;
    }

    //    public void Setup(Vector2Int newBoardPosition, Board newBoard, string button_text) {
    //        mBoardPosition = newBoardPosition;
    //        mBoard = newBoard;
    //        mRectTransform = GetComponent<RectTransform>();
    //        print("Setup called for cell");
    //
    //        //mLabel.text = button_text;
    //        mLabel.text = "new text";
    //    }
}
