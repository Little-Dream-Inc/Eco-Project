using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLabelController : MonoBehaviour
{
    ScoreManager scoreManager;
    TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreManager.ScoreChangedEvent += UpdateScore;
    }

    // Update is called once per frame
    void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
