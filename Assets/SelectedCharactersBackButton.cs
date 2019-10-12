using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectedCharactersBackButton : MonoBehaviour
{
    public void BackToMenu() {
        SceneManager.LoadScene("1_scroller_menu");
    }
}
