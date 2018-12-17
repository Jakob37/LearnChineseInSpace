using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

    public int max_life;
    private int current_life;

    public void Damage(int damage) {
        current_life -= damage;
        if (current_life <= 0) {
            Destroy(gameObject);
        }
    }

    public void Heal(int life) {
        current_life += life;
        current_life = Math.Min(current_life, max_life);
    }
}
