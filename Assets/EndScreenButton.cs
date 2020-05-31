using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenButton : MonoBehaviour
{
    public void BackToStart() {
        SceneManager.LoadScene("1_scroller_menu");
    }
}
