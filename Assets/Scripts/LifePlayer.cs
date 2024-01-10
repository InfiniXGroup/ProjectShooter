using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    public int maxLives; // Le nombre maximum de vies
    public int currentLives; // Le nombre de vies actuel
    public int startLives;
    public int minLives;
    [SerializeField] GameObject full;
    [SerializeField] GameObject mid;
    [SerializeField] GameObject bad;

    [SerializeField] AudioSource soundEffectSource;
    [SerializeField] AudioClip damage;
    [SerializeField] AudioClip death;

    [SerializeField] GameObject GameOverUI;

    public static LifePlayer instance;

    public bool loseEvent;

    private void Start()
    {
        UpdateLives();
        GameOverUI.SetActive(false);
        loseEvent = false;
        if (currentLives <= minLives)
            currentLives = startLives;
    }

    private void Awake()
    {
        instance = this;
    }

    // Cette fonction diminue le nombre de vies
    public void LoseLife(int amount)
    {
        if (loseEvent == false)
        {
            loseEvent = true;
            currentLives -= amount;
            if (currentLives <= 0)
            {
                soundEffectSource.PlayOneShot(death);
                currentLives = startLives;
                GameOverUI.SetActive(true);

            }
            else
                soundEffectSource.PlayOneShot(damage);

            UpdateLives();

        }
    }

    // Cette fonction augmente le nombre de vies
    public void GainLife(int amount)
    {
        currentLives += amount;
        if (currentLives > maxLives)
        {
            currentLives = maxLives;
        }
        UpdateLives();
    }

    // Met � jour l etat du joueur
    public void UpdateLives()
    {
        switch (currentLives)
        {
            case 0:
                full.SetActive(false);
                mid.SetActive(false);
                bad.SetActive(false);
                break;
            case 1:
                full.SetActive(false);
                mid.SetActive(false);
                bad.SetActive(true);
                break;
            case 2:
                full.SetActive(false);
                mid.SetActive(true);
                bad.SetActive(false);
                break;
            case 3:
                full.SetActive(true);
                mid.SetActive(false);
                bad.SetActive(false);
                break;
        }
    }
}
