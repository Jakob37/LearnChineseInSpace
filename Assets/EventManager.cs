using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public void TrigStep() {

        print("Step trigged!");
        BasicEnemy[] enemies = FindObjectsOfType<BasicEnemy>();
        foreach (BasicEnemy enemy in enemies) {
            Movement enemy_movement = enemy.transform.gameObject.GetComponent<Movement>();
            enemy_movement.Step();
        }

        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners) {
            spawner.TrigStep();
        }
    }
}
