using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour {

    private Life life;
    public bool invincible;

    void Start() {
        life = GetComponent<Life>();
    }

    public void InflictDamage(int damage) {
        if (!invincible) {
            life.Damage(damage);
        }
    }
}
