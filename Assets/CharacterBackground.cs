using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBackground : MonoBehaviour
{
    private SpriteRenderer my_renderer;

    void Awake() {
        my_renderer = GetComponent<SpriteRenderer>();
    }

    void Start() {
    }

    public void SetColor(Color color) {
        my_renderer.color = color;
    }
}
