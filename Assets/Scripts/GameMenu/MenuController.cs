using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
   public void StartBtn() // Clique sur le boutton Jouer
    {
        SceneManager.LoadScene("Dungeon"); // Charge la scene "Dungeon"
    }

    public void QuitBtn() // Clique sur le boutton quitter
    {
        Application.Quit();
    }
}
