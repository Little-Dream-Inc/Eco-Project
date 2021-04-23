using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EarnedScoreLabel : MonoBehaviour
{
    ScoreManager scoreManager;
    TextMeshProUGUI label; //TODO transfer to another script

    // Start is called before the first frame update
    void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
        scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.ScoreChangedEvent += UpdateLabel;
    }

    void UpdateLabel(int score)
    {
        label.text = "Earned: " + score;
    }
}
