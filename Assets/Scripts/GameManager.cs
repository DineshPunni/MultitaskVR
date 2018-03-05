using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject gameOverCanvas;
    public GameObject menuCanvas;

    public static Action OnStartGame;
    public static Action OnGameOver;
    public static Action OnGameWon;

    private bool batteryFull;
    private bool fuelFull;

    private void OnEnable()
    {
        TargetController.OnTargetDestroyed += GameOver;

        EnergyBoxController.OnBatteryDestroyed += GameOver;
        EnergyBoxController.OnBatteryFull += BatteryFull;

        FuelBoxController.OnFuelBoxDestroyed += GameOver;
        FuelBoxController.OnFuelFull += FuelFull;
    }

    private void OnDisable()
    {
        TargetController.OnTargetDestroyed -= GameOver;

        EnergyBoxController.OnBatteryDestroyed -= GameOver;
        EnergyBoxController.OnBatteryFull -= BatteryFull;

        FuelBoxController.OnFuelBoxDestroyed -= GameOver;
        FuelBoxController.OnFuelFull -= FuelFull;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartGame();
        }
    }
    void BatteryFull()
    {
        batteryFull = true;
        if (fuelFull)
            GameWon();
    }

    void FuelFull()
    {
        fuelFull = true;
        if (batteryFull)
            GameWon();
    }

    void GameWon()
    {
        GetComponent<AudioSource>().Play();

        Debug.Log("You won!");
        if (OnGameWon != null)
            OnGameWon();
    }

    public void StartGame()
    {
        ToggleMenus(false);

        if (OnStartGame != null)
            OnStartGame();
    }


    void GameOver()
    {
        ToggleMenus(true);

        if (OnGameOver != null)
            OnGameOver();
    }


    void ToggleMenus(bool value)
    {
        gameOverCanvas.SetActive(value);
        menuCanvas.SetActive(value);
    }
}
