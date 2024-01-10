using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void loadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
