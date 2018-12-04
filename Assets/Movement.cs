using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    Low = 50,
    Medium = 100,
    High = 200
}

public class Movement : MonoBehaviour {

    public XDir x;
    public YDir y;
    public Speed speed;

    public void ResetMovement() {
        x = 0;
        y = 0;
    }

    public void MoveRight() {
        x = XDir.Right;
    }

    public void MoveLeft() {
        x = XDir.Left;
    }

    public void MoveDown() {
        y = YDir.Down;
    }

    public void MoveUp() {
        y = YDir.Up;
    }

    void Update() {

        float delta_x = (int)x * (int)speed * Time.deltaTime;
        float delta_y = (int)y * (int)speed * Time.deltaTime;

        Vector3 pos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(pos.x + delta_x, pos.y + delta_y, pos.z);
    }
}