using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private GameObjects gos;
    public GameObject spawn_object;
    public float spawn_interval;
    private float current_spawn_time;

    void Awake() {
        gos = FindObjectOfType<GameObjects>();
    }

    void Update() {
        current_spawn_time += Time.deltaTime;
        if (current_spawn_time > spawn_interval) {
            Spawn();
            current_spawn_time = 0;
        }
    }

    private void Spawn() {
        GameObject spawn = Instantiate(spawn_object, gos.gameObject.transform);
        spawn.transform.position = gameObject.transform.position;
    }
}