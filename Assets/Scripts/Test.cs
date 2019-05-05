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

public class Test : MonoBehaviour
{

    private Transform transform;
    private Movement movement;

    void Start() {
        movement = GetComponent<Movement>();
        transform = gameObject.transform;
    }

    void Update() {
        //if (Input.anyKeyDown) {
        //    transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
        //}

        Vector2 dir = GetDirection();
        if (dir != Vector2.zero) {
            Move(dir);
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

        var scaled_dir = dir / dir.magnitude;

        return scaled_dir;
    }

    private void Move(Vector2 dir) {
        print("Move triggered");
        print(transform.position);

        float speed = 10;

        transform.position = new Vector2(transform.position.x + dir.x * speed, transform.position.y + dir.y * speed);

    }

    void OnMouseDown() {
        print("Success!");
    }
}
