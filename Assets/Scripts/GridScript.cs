using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour {

    public GameObject mCellPrefab;
    public int cells;

    private Cell[] mCells = new Cell[1000];

    void Start() {
        Build();
    }

    public void Build() {
        for (int i = 0; i <= cells; i++) {
            GameObject newCell = Instantiate(mCellPrefab, transform);

            mCells[i] = newCell.GetComponent<Cell>();
        }
    }
}