using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll) {

        if (coll.gameObject.GetComponent<EnemyParent>() != null) {
            EnemyParent enemy = coll.gameObject.GetComponent<EnemyParent>();
            enemy.InflictDamage(int.MaxValue);
            Destroy(enemy.transform.gameObject);
        }
    }
}
