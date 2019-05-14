using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public GameObject bullet_object;
    private GameObjects gos;
    private PlayerCube player;

    public float shoot_delay;
    private float current_shoot_timer;

    void Awake() {
        gos = FindObjectOfType<GameObjects>();
        player = FindObjectOfType<PlayerCube>();
    }

    void Start() {
        FireBullet();
        current_shoot_timer = shoot_delay;
    }

    private void FireBullet() {
        GameObject bullet = Instantiate(bullet_object, gos.gameObject.transform);
        bullet.transform.position = gameObject.transform.position;
        var movement = bullet.GetComponent<Movement>();

        Vector2 dir = ScaledDirTowards(player.transform.position);
        // bullet.transform.LookAt(player.transform);
        // bullet.transform.rotation = dir;
        print(dir);
        movement.AssignMovement(dir, Speed.High);
    }

    private Vector2 ScaledDirTowards(Vector3 pos) {
        Vector2 diff = pos - transform.position;
        Vector2 scaled_diff = diff / diff.magnitude;
        return scaled_diff;
    }

    void Update() {
        current_shoot_timer -= Time.deltaTime;
        if (current_shoot_timer <= 0) {
            current_shoot_timer = shoot_delay;
            FireBullet();
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        print("Colliding with enemy");

        if (coll.gameObject.GetComponent<Bullet>() != null) {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
