using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseCanvas;

    public bool paused;

    void Start()
    {
        pauseCanvas = GetComponent<Canvas>();
        pauseCanvas.enabled = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            pauseGame();
            paused = true;
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0f;
        pauseCanvas.enabled = true;
    }

    public void unpauseGame()
    {
        Time.timeScale = 1f;
        pauseCanvas.enabled = false;
        paused = false;
    }
}
