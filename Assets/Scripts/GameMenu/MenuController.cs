using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Clique sur le boutton Jouer
    public void StartBtn()
    {
        // Charge la scene "Dungeon"
        SceneManager.LoadScene("Dungeon");
    }

    // Clique sur le boutton quitter
    public void QuitBtn()
    {
        // Quite l'application
        Application.Quit();
    }
}
