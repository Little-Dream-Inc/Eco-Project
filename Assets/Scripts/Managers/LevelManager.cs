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
    [SerializeField] GameObject levelCompletedScreen;
    [SerializeField] Animator garbageTruck;

    [SerializeField] int totalLives;
    [SerializeField] float levelTime;

    bool isFailed;
    int livesCount;


    private void Start()
    {
        ResetLives();
        GameOverEvent += GameOver;
        StartCoroutine(LevelTimer());
    }

    public int GetLives() => livesCount;

    public void OnFail()
    {
        livesCount--;
        LivesChangedEvent(livesCount);
        if (livesCount <= 0)
        {
            isFailed = true;
            GameOverEvent();
        }
    }

    void GameOver()
    {
        if(isFailed)
        {
            gameOverScreen.GetComponent<RectTransform>().Rotate(Vector2.up, -90); //TODO Make it better way
        }
        else
        {
            levelCompletedScreen.GetComponent<RectTransform>().Rotate(Vector2.up, -90); //TODO Make it better way
            garbageTruck.SetTrigger("Win");
        }
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ResetLives()
    {
        livesCount = totalLives;
        LivesChangedEvent(livesCount);
    }

    IEnumerator LevelTimer()
    {
        float timer = levelTime;
        while(timer > 0)
        {
            yield return null;
            timer -= Time.deltaTime;

        }
        GameOverEvent();
    }
}
