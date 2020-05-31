using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtils : MonoBehaviour
{
    private Camera cam;

    void Awake() {
        cam = GetComponent<Camera>();
    }

    public Vector2 CameraPosToWorld(Vector2 camera_pos) {
        return cam.ScreenToWorldPoint(new Vector3(camera_pos.x, camera_pos.y, cam.nearClipPlane));
    }
}
