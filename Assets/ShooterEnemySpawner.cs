using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemySpawner : MonoBehaviour
{

    public GameObject enemy_prefab;
    private GameObjects gos;
    
    public float spawn_delay;
    public float spawn_delay_decrease;
    public float min_spawn_delay;
    private float current_spawn_timer;

    public float min_x;
    public float max_y;

    public int spawn_count;

    void Awake() {
        gos = FindObjectOfType<GameObjects>();
    }

    void Start() {
        // SpawnEnemy();
    }

    void Update() {
        current_spawn_timer -= Time.deltaTime;
        if (spawn_count > 0 && current_spawn_timer <= 0) {
            current_spawn_timer = spawn_delay;
            spawn_count -= 1;
            SpawnEnemy();
            spawn_delay -= spawn_delay_decrease;
        }
    }

    private void SpawnEnemy() {
        GameObject instance = Instantiate(enemy_prefab, gos.gameObject.transform);
        var gos_pos = gameObject.transform.position;
        instance.transform.position = new Vector2(gos_pos.x + Random.Range(min_x, max_y), gos_pos.y);
        ShooterEnemy enemy_script = instance.GetComponent<ShooterEnemy>();

        float stop_pos = Random.Range(300, 1000);
        enemy_script.Initialize(stop_pos);
    }
}
