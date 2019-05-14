using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public GameObject bullet_object;
    private GameObjects gos;
    private PlayerCube player;

    void Awake() {
        gos = FindObjectOfType<GameObjects>();
        player = FindObjectOfType<PlayerCube>();
    }

    void Start() {
        FireBullet();
    }

    private void FireBullet() {
        GameObject bullet = Instantiate(bullet_object, gos.gameObject.transform);
        bullet.transform.position = gameObject.transform.position;
        var movement = bullet.GetComponent<Movement>();

        Vector2 scaled = ScaledDirTowards(player.transform.position);
        print(scaled);
        movement.AssignMovement(scaled, Speed.High);
    }

    private Vector2 ScaledDirTowards(Vector3 pos) {
        Vector2 diff = transform.position - pos;
        Vector2 scaled_diff = diff / diff.magnitude;
        return scaled_diff;
    }

    void Update() {
        
    }

    void OnCollisionEnter2D(Collision2D coll) {
        print("Colliding with enemy");

        if (coll.gameObject.GetComponent<Bullet>() != null) {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
