using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public delegate void OnLivesChanged(int lives);
    public event OnLivesChanged LivesChangedEvent;

    public delegate void OnGameOver();
    public event OnGameOver GameOverEvent;

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] int totalLives;
    int livesCount;


    private void Start()
    {
        ResetLives();
        GameOverEvent += GameOver;
    }

    public int GetLives() => livesCount;

    public void OnFail()
    {
        livesCount--;
        LivesChangedEvent(livesCount);
        if (livesCount <= 0)
        {
            GameOverEvent();
        }
    }

    void GameOver()
    {
        gameOverScreen.GetComponent<RectTransform>().Rotate(Vector2.up, -90); //TODO Make it better way
        if(Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            OnRestart();
        }
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
