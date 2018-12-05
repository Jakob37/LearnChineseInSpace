using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage;

    void OnTriggerEnter2D(Collider2D coll) {
        // print("Colliding with: " + coll.ToString());

        if (coll.gameObject.GetComponent<EnemyParent>() != null) {
            print("Enemy hit!");
            EnemyParent enemy = coll.gameObject.GetComponent<EnemyParent>();
            enemy.InflictDamage(damage);
            Destroy(gameObject);
        }
        // coll.gameObject
    }

}