using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void GameBegin()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void Leave()
    {
        Application.Quit();
    }
}
