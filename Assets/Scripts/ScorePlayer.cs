using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer : MonoBehaviour
{
    public int minScore; // Le nombre maximum de vies
    public int currentScore;
    public Text ScoreText;
    public static ScorePlayer instance;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        if (currentScore <= minScore)
            currentScore = minScore;
    
    }

    private void Awake()
    {
        instance = this;
    }

    public void GainScore(int amount)
    {
        currentScore += amount;
        if (currentScore <= minScore)
            currentScore = minScore;
        UpdateScore();
    }

    public void UpdateScore()
    {
        if (ScoreText != null)
        {
            ScoreText.text = currentScore.ToString();
        }
    }
}
