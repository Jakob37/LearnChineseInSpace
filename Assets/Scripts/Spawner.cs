using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawn_object;
    private float screen_size;
    private System.Random random;
    private const float scale_size = 1.4f;
    private const float grid_size = 50;

    private int remain_to_spawn;
    private int spawn_steps;

    void Start() {
        screen_size = 650;
        random = new System.Random();
        spawn_steps = 1;
    }

    public void TrigStep(bool chars_left=true) {

        remain_to_spawn--;
        if (remain_to_spawn <= 0 || !chars_left) {
            NewSpawn();
            remain_to_spawn = spawn_steps;
        }
    }

    private void NewSpawn() {

        Array values = Enum.GetValues(typeof(CharacterType));
        CharacterType char_type = (CharacterType)values.GetValue(random.Next(values.Length));

        GameObject new_object = UnityEngine.Object.Instantiate(spawn_object);
        var x_pos = (int)(UnityEngine.Random.Range(-screen_size / 2, screen_size / 2) / grid_size) * grid_size;
        new_object.gameObject.transform.position = new Vector2(gameObject.transform.position.x + x_pos, gameObject.transform.position.y);
        new_object.gameObject.transform.localScale = new Vector2(scale_size, scale_size);
        var obj_char = new_object.GetComponent<Character>();
        obj_char.Initialize(char_type);

    }
}
