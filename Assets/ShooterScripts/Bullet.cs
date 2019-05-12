using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int destroy_interval = -100;

    void Start() {
        
    }

    void Update() {
        
        if (transform.position.y < destroy_interval) {
            print("Destroyed bullet due to position");
            Destroy(gameObject);
        }

    }
}
