using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int currentScore = 0;
    int HighScore = 0;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveY(ScoreText.gameObject.GetComponent<RectTransform>(), 477f, 1f);
        LeanTween.moveY(HighScoreText.gameObject.GetComponent<RectTransform>(), 477f, 1f);
        ScoreText.text = "Score : 0";

        if (PlayerPrefs.HasKey("Highscore"))
        {
            HighScore = PlayerPrefs.GetInt("Highscore");
            HighScoreText.text = "High Score : " + HighScore.ToString();
        }
    }


    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void AddScore(int value)
    {
        currentScore += value;
        UpdateScore();
        HighestScore();
    }

    private void UpdateScore()
    {
        ScoreText.text = "Score : " + currentScore.ToString();

        if(LevelManager.instance.PlayerPrefab == null)
        {
            HighestScore();
        }
    }

    private void HighestScore()
    {
        if (currentScore > PlayerPrefs.GetInt("Highscore"))
            PlayerPrefs.SetInt("Highscore", currentScore);

    }

    
} 