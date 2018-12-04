using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Movement movement;
    public GameObject bullet;
    private GameObjects gos;

    void Awake() {
        movement = GetComponent<Movement>();
        gos = FindObjectOfType<GameObjects>();
    }


    void Update() {

        UpdateMovement();
        if (Input.GetKeyDown(KeyCode.Space)) {
            Fire();
        }
    }

    private void UpdateMovement() {
        movement.ResetMovement();
        if (Input.GetKey(KeyCode.LeftArrow)) {
            movement.MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            movement.MoveRight();
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            movement.MoveUp();
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            movement.MoveDown();
        }
    }

    private void Fire() {
        GameObject b = Instantiate(bullet, gos.gameObject.transform);
        b.transform.position = gameObject.transform.position;
    }

}