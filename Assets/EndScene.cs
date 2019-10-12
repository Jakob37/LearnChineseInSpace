using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("Score: " + PlayerStats.score);
        foreach (string character in PlayerStats.incorr_chars) {
            print("You missed on: " + character);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
