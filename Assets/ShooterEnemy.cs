using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShooterEnemyBehaviour {
    MovingSilently,
    MovingShooting,
    StoppingShooting
}

public class ShooterEnemy : MonoBehaviour
{
    public GameObject bullet_object;
    private GameObjects gos;
    private PlayerCube player;
    private Movement movement;

    public Color start_tint;
    private Color end_tint;

    public int health;

    private SpriteRenderer sprite_renderer;

    private float start_shoot_interval;
    public float shoot_interval;
    public float shoot_interval_decrease;
    public float shoot_interval_min;
    private float current_shoot_timer;
    private ShooterEnemyBehaviour behaviour;

    private float stop_position;

    public float shooting_delay;
    private float time_since_spawn;

    private Random my_rand;

    void Awake() {
        sprite_renderer = GetComponent<SpriteRenderer>();
        gos = FindObjectOfType<GameObjects>();
        player = FindObjectOfType<PlayerCube>();
        behaviour = ShooterEnemyBehaviour.MovingSilently;
        movement = GetComponent<Movement>();
        my_rand = new Random();
        start_shoot_interval = shoot_interval;
    }

    void Start() {
        current_shoot_timer = shoot_interval;
        time_since_spawn = 0;
        end_tint = sprite_renderer.color;
        sprite_renderer.color = start_tint;
        // print(start_tint);
    }

    public void Initialize(float stop_position) {
        this.stop_position = stop_position;
        // print("Stop position: " + this.stop_position);
    }

    private Vector2 ScaledDirTowards(Vector3 pos) {
        Vector2 diff = pos - transform.position;
        Vector2 scaled_diff = diff / diff.magnitude;
        return scaled_diff;
    }

    void Update() {

        time_since_spawn += Time.deltaTime;

        if (behaviour == ShooterEnemyBehaviour.MovingSilently) {
            behaviour = MovingSilently();
        }
        else if (behaviour == ShooterEnemyBehaviour.MovingShooting) {
            behaviour = MovingShooting();
        }
        else if (behaviour == ShooterEnemyBehaviour.StoppingShooting) {
            behaviour = StoppingShooting();
        }
        else {
            throw new System.Exception("Unknown behaviour: " + behaviour);
        }

        float heat_frac = HeatupFraction();
        if (heat_frac > 0) {
            sprite_renderer.color = Color.Lerp(start_tint, end_tint, heat_frac);
        }
    }

    private float HeatupFraction() {
        float full_range = start_shoot_interval - shoot_interval_min;
        float curr_range = start_shoot_interval - shoot_interval;
        float curr_frac = curr_range / full_range;
        return curr_frac;
    }

    private ShooterEnemyBehaviour MovingSilently() {
        if (transform.position.y < stop_position) {
            return ShooterEnemyBehaviour.StoppingShooting;
        }
        else if (time_since_spawn > shooting_delay) {
            print("Switching to moving shooting");
            return ShooterEnemyBehaviour.MovingShooting;
        }
        else {
            return ShooterEnemyBehaviour.MovingSilently;
        }
    }

    private ShooterEnemyBehaviour MovingShooting() {
        UpdateShooting();
        if (transform.position.y < stop_position) {
            print("Switching to stopping shooting");
            return ShooterEnemyBehaviour.StoppingShooting;
        }
        else {
            return ShooterEnemyBehaviour.MovingShooting;
        }
    }

    private ShooterEnemyBehaviour StoppingShooting() {

        movement.speed = Speed.None;
        if (player != null) {
            UpdateShooting();
        }
        return ShooterEnemyBehaviour.StoppingShooting;
    }

    private void UpdateShooting() {
        current_shoot_timer -= Time.deltaTime;
        if (current_shoot_timer <= 0 && player.IsAlive) {
            current_shoot_timer = shoot_interval;
            FireBullet();
            if (shoot_interval > shoot_interval_min) {
                shoot_interval -= shoot_interval_decrease;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {

        if (coll.gameObject.GetComponent<Bullet>() != null) {
            Destroy(coll.gameObject);
            int damage = coll.gameObject.GetComponent<Damage>().damage;
            InflictDamage(damage);
        }
    }

    private void InflictDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    private void FireBullet() {
        GameObject bullet = Instantiate(bullet_object, gos.gameObject.transform);

        bullet.transform.position = gameObject.transform.position;
        var movement = bullet.GetComponent<Movement>();
        Vector2 dir = ScaledDirTowards(player.transform.position);
        movement.AssignMovement(dir, Speed.High);
    }
}
