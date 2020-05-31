using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum XDir {
    Left = -1,
    Right = 1,
    None = 0
}

public enum YDir {
    Up = 1,
    Down = -1,
    None = 0
}

public enum Speed {
    None = 0,
    Low = 100,
    Medium = 200,
    High = 800,
    ExtremelyHigh = 1500
}

public class Movement : MonoBehaviour {

    public float x;
    public float y;
    public Speed speed;

    public bool is_step;

    public bool use_bound;
    public float x_min_bound;
    public float x_max_bound;
    public float y_min_bound;
    public float y_max_bound;

    private Vector2 waypoint;
    private Coordinates coordinates;

    void Awake() {
        coordinates = FindObjectOfType<Coordinates>();
    }

    void Start() {
        waypoint = Vector2.zero;
    }

    public void Step() {
        float delta_x = (int)x * (int)speed;
        float delta_y = (int)y * (int)speed;
        Vector3 pos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(pos.x + delta_x, pos.y + delta_y, pos.z);
    }

    public void AssignMovement(Vector2 dir, Speed speed) {
        this.speed = speed;
        x = dir.x;
        y = dir.y;
    }

    public void ResetMovement() {
        x = 0;
        y = 0;
    }

    public void MoveRight() {
        x = 1;
    }

    public void MoveLeft() {
        x = -1;
    }

    public void MoveDown() {
        y = 1;
    }

    public void MoveUp() {
        y = -1;
    }

    void Update() {

        if (!is_step) {
            UpdateWaypointMovement();
        }
        else {
            UpdateStepMovement();
        }
    }

    private void UpdateWaypointMovement() {

        if (Input.GetMouseButtonDown(0) && Input.mousePosition.y > coordinates.GetSeparator()) {
            waypoint = Input.mousePosition;
        }

        if (waypoint != Vector2.zero) {

            var new_pos = Vector3.MoveTowards(gameObject.transform.position, waypoint, (float)speed * Time.deltaTime * 5);
            gameObject.transform.position = new_pos;

            if (new_pos.x == waypoint.x && new_pos.y == waypoint.y) {
                waypoint = Vector2.zero;
            }
        }
    }

    private void UpdateStepMovement() {
        float delta_x = x * (float)speed * Time.deltaTime;
        float delta_y = y * (float)speed * Time.deltaTime;
        Vector3 pos = gameObject.transform.position;

        Vector3 new_pos;
        if (use_bound) {
            print(pos);
            new_pos = new Vector3(
                Mathf.Clamp(pos.x + delta_x, x_min_bound, x_max_bound),
                Mathf.Clamp(pos.y + delta_y, y_min_bound, y_max_bound),
                pos.z
            );
        }
        else {
            new_pos = new Vector3(pos.x + delta_x, pos.y + delta_y, pos.z);
        }

        gameObject.transform.position = new_pos;
    }
}