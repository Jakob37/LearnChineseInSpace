using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawn_object;
    public void TrigStep() {
        print("Triggering spawner");
        GameObject new_object = Object.Instantiate(spawn_object);
        float screen_size = 700;
        var x_pos = Random.Range(-screen_size / 2, screen_size / 2);
        // new_object.gameObject.transform.parent = gameObject.transform;
        new_object.gameObject.transform.position = new Vector2(gameObject.transform.position.x + x_pos, gameObject.transform.position.y);
        new_object.gameObject.transform.localScale = new Vector2(0.5f, 0.5f);
        var obj_char = new_object.GetComponent<Character>();
        obj_char.Initialize();
    }
}
