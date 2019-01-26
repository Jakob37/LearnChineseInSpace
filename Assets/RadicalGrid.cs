using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadicalGrid : MonoBehaviour
{
    private GridLayout grid;
    public GameObject test_object;

    void Awake() {

        TestObject[] objs = GetComponentsInChildren<TestObject>();

        foreach (TestObject obj in objs) {
            Destroy(obj.gameObject);
        }

        for (int i = 0; i < 50; i++) {
            print("Creating instance");
            GameObject instance = Instantiate(test_object);
            instance.transform.SetParent(gameObject.transform);
        }
    }
}
