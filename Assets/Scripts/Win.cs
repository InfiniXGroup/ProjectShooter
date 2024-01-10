using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    Collision2D other;
    [SerializeField] GameObject canvas;

    public static Win instance;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    private void Awake()
    {
        instance = this; // Initialisez la r�f�rence instance
    }


    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("JeJe");
            canvas.SetActive(true);
        }
    }
}
