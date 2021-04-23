using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    LevelManager levelManager;

    public delegate void OnPause();
    public event OnPause OnPauseEvent;

    bool paused;
    bool stopped;

    private void Start()
    {
        levelManager = GetComponent<LevelManager>();
        levelManager.GameOverEvent += StopGame;
        OnPauseEvent += OnGamePause;
    }
    public void OnPauseButton()
    {
        OnPauseEvent();
    }

    void StopGame()
    {
        stopped = true;
        OnPauseEvent();
    }

    void OnGamePause()
    {
        if (paused && stopped) return;
        Time.timeScale = paused ? 1 : 0;
        paused = !paused;
    }

}
