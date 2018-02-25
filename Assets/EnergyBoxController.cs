using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBoxController : MonoBehaviour  {



    public float maxHealth;
    public float currentHealth;
    public float healthDecrease;
    public float batteryCharge;

    private bool gameStarted;

    private void OnEnable()
    {
        BatteryCharging.OnBatteryEmpty += IncreaseHealth;
        GameManager.OnStartGame += StartGame;
        GameManager.OnGameOver += GameOver;
    }

   

    private void OnDisable()
    {
        BatteryCharging.OnBatteryEmpty -= IncreaseHealth;
        GameManager.OnStartGame -= StartGame;
        GameManager.OnGameOver -= GameOver;
    }

    private void IncreaseHealth(GameObject obj)
    {
        currentHealth += batteryCharge;
    }

 
	void Update () {

        if(gameStarted)
            currentHealth -= Time.deltaTime * healthDecrease;
	}


    void StartGame()
    {
        currentHealth = maxHealth;
        gameStarted = true;
    }


    public void GameOver()
    {
        gameStarted = false;
    }
}
