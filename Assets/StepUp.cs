using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepUp : MonoBehaviour {

    private Grids grids;

    void Awake() {
        grids = FindObjectOfType<Grids>();
    }

    public void AddWords(int word_count) {

        grids.AddWords(word_count);
    }
}