using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour
{

    private PlayerCube player;
    private RuntimePlatform platform;
    private Collider2D coll;

    void Awake() {
        player = FindObjectOfType<PlayerCube>();
    }

    void Start() {
        platform = Application.platform;
        coll = GetComponent<Collider2D>();
    }

    void Update() {
        if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) {
            if (Input.touchCount > 0) {
                if (Input.GetTouch(0).phase == TouchPhase.Began) {
                    checkTouch(Input.GetTouch(0).position);
                }
            }
        }
        else if (platform == RuntimePlatform.WindowsEditor) {
            if (Input.GetMouseButtonDown(0)) {
                checkTouch(Input.mousePosition);
            }
        }

    }

    private void checkTouch(Vector3 pos) {

        print("Checking touch");

        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        var hit = coll.bounds.Contains(touchPos);

        if (hit) {
            print("fire button clicked!");
            player.TryFire();
        }
    }
}
