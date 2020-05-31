using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates : MonoBehaviour
{

    private Coordinate[] coords;

    void Start() {
        coords = GetComponentsInChildren<Coordinate>();
    }

    private float get_pos(string label, string axis) {
        foreach (Coordinate coord in coords) {
            if (coord.label == label) {
                if (axis == "x") {
                    return coord.transform.position.x;
                }
                else if (axis == "y") {
                    return coord.transform.position.y;
                }
                else {
                    throw new System.Exception("Unknown axis: " + axis);
                }
            }
        }
        throw new System.Exception("Missing coordinate object for label: " + label);

    }

    public float GetTop() {
        return get_pos("top", "y");
    }

    public float GetBottom() {
        return get_pos("bottom", "y");
    }

    public float GetLeft() {
        return get_pos("left", "x");
    }

    public float GetRight() {
        return get_pos("right", "x");
    }

    public float GetSeparator() {
        return get_pos("separator", "y");
    }
}
