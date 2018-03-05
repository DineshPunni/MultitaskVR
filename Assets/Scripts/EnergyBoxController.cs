using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBoxController : MonoBehaviour  {


    public static Action OnBatteryDestroyed;
    public static Action OnBatteryFull;

    [Header("Balancing")]
    public float maxHealth;
    [HideInInspector]
    public float currentHealth;
    public float healthDecrease;
    public float batteryCharge;
    public float chargeTime;

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

 
	void Update ()
    {

        if(gameStarted && currentHealth>=0)
            currentHealth -= Time.deltaTime * healthDecrease;

        if (currentHealth >= 100)
            if (OnBatteryFull != null)
                OnBatteryFull();

        //if (currentHealth <= 0)
        //    if (OnBatteryDestroyed != null)
        //        OnBatteryDestroyed();

    }


    void StartGame()
    {
        //currentHealth = maxHealth;
        gameStarted = true;
    }


    public void GameOver()
    {
        gameStarted = false;
    }
}
