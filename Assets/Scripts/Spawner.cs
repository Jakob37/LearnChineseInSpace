using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawn_object;
    private float screen_size;
    private System.Random random;

    void Start() {
        screen_size = 680;
        random = new System.Random();
    }

    public void TrigStep() {
        NewSpawn();
    }

    private void NewSpawn() {

        Array values = Enum.GetValues(typeof(CharacterType));
        CharacterType char_type = (CharacterType)values.GetValue(random.Next(values.Length));

        GameObject new_object = UnityEngine.Object.Instantiate(spawn_object);
        var x_pos = UnityEngine.Random.Range(-screen_size / 2, screen_size / 2);
        new_object.gameObject.transform.position = new Vector2(gameObject.transform.position.x + x_pos, gameObject.transform.position.y);
        float scale_size = 1;
        new_object.gameObject.transform.localScale = new Vector2(scale_size, scale_size);
        var obj_char = new_object.GetComponent<Character>();
        obj_char.Initialize(char_type);

    }
}
