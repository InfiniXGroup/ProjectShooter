using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScorePlayer : MonoBehaviour
{
    public static ScorePlayer instance;


    public int minScore; // Le nombre maximum de vies
    public int currentScore;
    public TMP_Text ScoreText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        if (currentScore <= minScore)
            currentScore = minScore;
    
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
