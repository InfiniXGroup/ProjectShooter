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
        instance = this;
        ScorePlayer.instance = FindObjectOfType<ScorePlayer>();
    }

    public void modifyScore(int number)
    {
        ScorePlayer.instance.GainScore(number);
    }
}
