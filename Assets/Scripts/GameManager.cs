using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen;

    // Start is called before the first frame update
    void Awake()
    {
        startScreen = GameObject.FindGameObjectWithTag("StartScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMenu()
    {
        startScreen.SetActive(true);
        Time.timeScale = 0;
    }

    // Gets called from start screen button
    public void RemoveStartScreen()
    {
        startScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
