using System;
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

    private List<Cell> mCells;
    public int font_size;
    private Grids parent;

    public bool HasActiveCell { get { return active_cell != null; } }

    private Cell active_cell;
    public Cell ActiveCell { get { return active_cell; } }

    public float cellHeight;

    void Awake() {
        mCells = new List<Cell>();
    }

    public void ChildActivated(Cell cell) {
        active_cell = cell;
        foreach (Cell c in mCells) {
            c.GridCellActivated(cell);
        }
        this.parent.CellActivated();
    }

    public void CorrectSelection() {
        Destroy(active_cell.gameObject);
        mCells.Remove(active_cell);
        active_cell = null;
    }

    public void Build(Grids parent, List<ChineseEntry> chinese_entries, GridLanguage cell_type) {

        foreach (Cell cell in mCells) {
            Destroy(cell.gameObject);
        }
        mCells.Clear();

        this.parent = parent;
        int fill_count = Math.Min(cells, chinese_entries.Count);

        for (int i = 0; i < fill_count; i++) {

            GameObject newCell = Instantiate(mCellPrefab, transform);
            mCells.Add(newCell.GetComponent<Cell>());
            ChineseEntry chinese_entry = chinese_entries[i];
            mCells[i].Setup(this, chinese_entry,  cell_type, font_size);
        }
    }
}
