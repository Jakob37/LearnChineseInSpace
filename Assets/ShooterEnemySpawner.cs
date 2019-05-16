using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemySpawner : MonoBehaviour
{

    public GameObject enemy_prefab;
    private GameObjects gos;
    
    public float spawn_delay;
    private float current_spawn_timer;

    public float min_x;
    public float max_y;

    void Awake() {
        gos = FindObjectOfType<GameObjects>();
    }

    void Start() {
        SpawnEnemy();
    }

    void Update() {
        current_spawn_timer -= Time.deltaTime;
        if (current_spawn_timer <= 0) {
            current_spawn_timer = spawn_delay;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy() {
        GameObject instance = Instantiate(enemy_prefab, gos.gameObject.transform);
        var gos_pos = gameObject.transform.position;
        instance.transform.position = new Vector2(gos_pos.x + Random.Range(min_x, max_y), gos_pos.y);
    }
}
