using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PointScoreManager : MonoBehaviour
{
    public static PointScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void modifyScore(int number)
    {
        if (ScorePlayer.instance != null)
        {
            ScorePlayer.instance.GainScore(number);
        }
        else
        {
            Debug.Log("Score Player is missing !!!");
        }
    }
}
