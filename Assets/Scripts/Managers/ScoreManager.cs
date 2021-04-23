using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    LevelManager levelManager;

    public delegate void OnScoreChanged(int score);
    public event OnScoreChanged ScoreChangedEvent;

    int currentScore; //TODO make accessor

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GetComponent<LevelManager>();
        levelManager.GameOverEvent += OnGameOver;
        ResetScore();
    }

    void OnGameOver()
    {
        ScoreChangedEvent(currentScore);
    }

    // Update is called once per frame
    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        ScoreChangedEvent(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
        ScoreChangedEvent(currentScore);
    }
}
