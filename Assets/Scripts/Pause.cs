using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPaused;
    public void OnPauseButton()
    {
        if(isPaused)
        {
            OnGameUnPause();
            isPaused = false;
        }
        else
        {
            OnGamePause();
            isPaused = true;
        }
    }

    void OnGamePause()
    {
        Time.timeScale = 0;
    }

    void OnGameUnPause()
    {
        Time.timeScale = 1;
    }
}
