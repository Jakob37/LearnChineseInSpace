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

    public void Setup(Vector2Int newBoardPosition, Board newBoard, string button_text) {
        mBoardPosition = newBoardPosition;
        mBoard = newBoard;
        mRectTransform = GetComponent<RectTransform>();

        mLabel.text = button_text;
        // mLabel = new Text("test");
    }
}
