using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesLabelController : MonoBehaviour
{
    LevelManager levelManager;
    TextMeshProUGUI livesText;
    // Start is called before the first frame update
    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        livesText = GetComponent<TextMeshProUGUI>();
        levelManager.LivesChangedEvent += UpdateLives;
    }

    void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }
}
