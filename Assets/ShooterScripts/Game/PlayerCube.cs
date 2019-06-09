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
    public int health;

    public bool IsAlive {
        get {
            return health > 0;
        }
    }

    void Awake() {
        gos = FindObjectOfType<GameObjects>();
        health_display = FindObjectOfType<HealthDisplay>();
    }

    void Start() {
        movement = GetComponent<Movement>();
        transform = gameObject.transform;
    }

    public void TrigCorrectEvent(ShooterCharacter character) {
        FireBullet();
    }

    void Update() {
        float speed = 10;
        Vector2 dir = GetDirection();
        Move(dir, speed);

        health_display.SetHealth(health);

        if (health <= 0) {
            Destroy(gameObject);
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
        transform.position = new Vector2(transform.position.x + dir.x * speed, transform.position.y + dir.y * speed);
    }

    void OnMouseDown() {
        print("Success!");
    }

    private void FireBullet() {
        GameObject instance = Instantiate(test_bullet, gos.gameObject.transform);
        instance.transform.position = gameObject.transform.position;
    }

    void OnCollisionEnter2D(Collision2D coll) {

        if (coll.gameObject.GetComponent<EnemyBullet>() != null) {
            print("hit player!");
            Destroy(coll.gameObject);
            health -= 1;
        }
    }
}
