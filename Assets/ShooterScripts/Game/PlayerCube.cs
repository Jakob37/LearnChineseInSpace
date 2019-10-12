using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
    Up,
    Down,
    Left,
    Right,
    None
}

public class PlayerCube : MonoBehaviour
{

    private Transform transform;
    private Movement movement;
    private GameObjects gos;

    public GameObject test_bullet;

    private HealthDisplay health_display;
    private EnergyDisplay energy_display;
    public int health;
    public int energy;
    public float speed;

    public float x_min_bound;
    public float x_max_bound;
    public float y_min_bound;
    public float y_max_bound;

    public bool IsAlive {
        get {
            return health > 0;
        }
    }

    void Awake() {
        gos = FindObjectOfType<GameObjects>();
        health_display = FindObjectOfType<HealthDisplay>();
        energy_display = FindObjectOfType<EnergyDisplay>();
    }

    void Start() {
        movement = GetComponent<Movement>();
        transform = gameObject.transform;
    }

    public void TrigCorrectEvent(ShooterCharacter character, int energy_points=1) {
        energy += energy_points;
    }

    void Update() {
        Vector2 dir = GetDirection();
        Move(dir, speed);

        health_display.SetHealth(health);
        energy_display.SetEnergy(energy);

        if (health <= 0) {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space) && energy > 0) {
            FireBullet();
            energy--;
        }
    }

    private Vector2 GetDirection() {

        Vector2 dir = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.LeftArrow)) {
            dir = new Vector2(-1, dir.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            dir = new Vector2(1, dir.y);
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            dir = new Vector2(dir.x, 1);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            dir = new Vector2(dir.x, -1);
        }

        var scaled_dir = dir;
        if (dir.x != 0 || dir.y != 0) {
            scaled_dir = dir / dir.magnitude;
        }

        return scaled_dir;
    }

    private void Move(Vector2 dir, float speed) {
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x + dir.x * speed, x_min_bound, x_max_bound), 
            Mathf.Clamp(transform.position.y + dir.y * speed, y_min_bound, y_max_bound)
        );
    }

    private void FireBullet() {
        GameObject instance = Instantiate(test_bullet, gos.gameObject.transform);
        instance.transform.position = gameObject.transform.position;
    }

    void OnCollisionEnter2D(Collision2D coll) {

        if (coll.gameObject.GetComponent<EnemyBullet>() != null) {
            Destroy(coll.gameObject);
            health -= 1;
        }
    }
}
