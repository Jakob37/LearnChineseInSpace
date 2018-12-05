using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Movement movement;
    public GameObject bullet;
    private GameObjects gos;

    private int currency;
    public int Currency { get { return currency; } }

    void Awake() {
        movement = GetComponent<Movement>();
        gos = FindObjectOfType<GameObjects>();
    }

    void Start() {
        currency = 0;
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

    public void AddCurrency(int count) {
        currency += count;
    }

    public void Fire() {
        GameObject b = Instantiate(bullet, gos.gameObject.transform);
        b.transform.position = gameObject.transform.position;
    }


}