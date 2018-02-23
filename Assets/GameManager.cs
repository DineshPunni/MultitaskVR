using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject gameOverCanvas;
    public GameObject menuCanvas;

    public static Action OnStartGame;
    public static Action OnGameOver;


    private void OnEnable()
    {
        TargetHealth.OnTargetDestroyed += GameOver;
    }

    private void OnDisable()
    {
        TargetHealth.OnTargetDestroyed -= GameOver;
    }

    void GameOver()
    {
        Debug.Log("Game Over");

        gameOverCanvas.SetActive(true);
        menuCanvas.SetActive(true);

        if (OnGameOver != null)
            OnGameOver();
    }

    public void StartGame()
    {
        gameOverCanvas.SetActive(false);
        menuCanvas.SetActive(false);

        Debug.Log("game starto");

        if (OnStartGame != null)
            OnStartGame();
    }


    void Start () {
		
	}
	
	void Update () {
		
	}

    

}
