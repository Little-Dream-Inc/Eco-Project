using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public delegate void OnLivesChanged(int lives);
    public event OnLivesChanged LivesChangedEvent;

     
    [SerializeField] int totalLives;
    int livesCount;

    private void Start()
    {
        ResetLives();
    }

    public int GetLives() => livesCount;

    public void OnFail()
    {
        livesCount--;
        LivesChangedEvent(livesCount);
        if (livesCount <= 0)
        {
            OnGameOver();
        }
    }

    void OnGameOver()
    {
        OnRestart();
    }

    void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ResetLives()
    {
        livesCount = totalLives;
        LivesChangedEvent(livesCount);

    }
}
