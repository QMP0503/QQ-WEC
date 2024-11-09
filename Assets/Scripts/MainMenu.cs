using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start game
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1); // Load scene to game scene by index
    }

    // Quit game
    public void ExitGame()
    {
        Application.Quit();
    }
}