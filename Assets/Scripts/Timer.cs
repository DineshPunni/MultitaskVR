using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {


    bool isStarted;
    float time;
    Text timeText;

   
    private void OnEnable()
    {
        GameManager.OnStartGame += StartTimer;
        GameManager.OnGameOver += StopTimer;
        GameManager.OnGameWon += StopTimer;
    }

    private void OnDisable()
    {
        GameManager.OnStartGame -= StartTimer;
        GameManager.OnGameOver -= StopTimer;
        GameManager.OnGameWon -= StopTimer;
    }


    private void Start()
    {
        timeText = GetComponent<Text>();
    }


    void Update()
    {
        if (isStarted)
            time += Time.deltaTime;

        timeText.text = time.ToString("F2");
    }


    void StartTimer ()
    {
        time = 0;
        isStarted = true;   
	}
	
    void StopTimer()
    {
        isStarted = false;
    }
}
