using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    public delegate void OnPause(bool isPaused);
    public event OnPause OnPauseEvent;

    bool paused;

    private void Start()
    {
        OnPauseEvent += OnGamePause;
    }
    public void OnPauseButton()
    {
        OnPauseEvent(paused);
    }

    void OnGamePause(bool isPaused)
    {
        Time.timeScale = isPaused ? 1 : 0;
        paused = !paused;
    }

}
