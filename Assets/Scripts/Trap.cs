using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    Collision2D other;
    [SerializeField] GameObject canvas;

    public static Trap instance;

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
    void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Collider>().CompareTag("Player"))
        {
            Debug.Log("hehe");
            canvas.SetActive(true);
        }
    }
}
