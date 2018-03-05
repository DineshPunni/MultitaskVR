using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class FuelBoxController : MonoBehaviour {

    public static Action OnFuelBoxDestroyed;
    public static Action OnFuelFull;

    [Header("References")]
    public List<GameObject> switches;
    public GameObject checkLight;
    public Text patternText;
    
    List<bool> handleValues = new List<bool>(new bool[] { false, false, false });
    List<bool> pattern = new List<bool>(new bool[] {false,false,false });

    string patterntext;

    bool gameStarted;

    [Header("Balancing")]
    public float maxHealth;
    [HideInInspector]
    public float currentHealth;
    public float healthDecrease;
    public float fuelCharge;
    public float chargeTime;

    void OnEnable()
    {
        GameManager.OnStartGame += StartGame;
        GameManager.OnGameOver += GameOver;
    }

    void OnDisable()
    {
        GameManager.OnStartGame -= StartGame;
        GameManager.OnGameOver -= GameOver;
    }

    void Update()
    {
        if (gameStarted && currentHealth>=0)
            currentHealth -= Time.deltaTime * healthDecrease;

        if (currentHealth >= 100)
            if (OnFuelFull != null)
                OnFuelFull();

        //if (currentHealth <= 0)
        //    if (OnFuelBoxDestroyed != null)
        //        OnFuelBoxDestroyed();
    }


    void StartGame()
    {
        //currentHealth = maxHealth;
        gameStarted = true;
    }

    void GameOver()
    {
        gameStarted = false;
    }

    public void ButtonPress(GameObject button)
    {
        for (int i = 0; i < switches.Count; i++)
        {
            LinearMapping lm =  switches[i].GetComponentInChildren<LinearMapping>();
          
            bool isHandleActivated = lm.value >= 0.5 ? true : false;
            handleValues[i] = isHandleActivated;
        }

        var isCorrect = CompareWithPattern();
        Color newColor = isCorrect == true ? Color.green : Color.red;
        checkLight.GetComponent<Renderer>().material.color = newColor;

        if (isCorrect)
        {
            Invoke("CreateNewPattern", chargeTime);
            button.GetComponent<AudioSource>().Play();
        }
    }

    bool CompareWithPattern()
    {
        for (int i = 0; i < handleValues.Count; i++)
        {
            if (handleValues[i] != pattern[i])
                return false;
        }

        return true;
    }

    public void CreateNewPattern()
    {
        GetComponent<AudioSource>().Play();
        currentHealth += fuelCharge;

        checkLight.GetComponent<Renderer>().material.color = Color.yellow;

        patterntext = "";

        for (int i = 0; i < pattern.Count; i++)
        {
            var rand = UnityEngine.Random.Range(0.0f, 1.0f);
            if (rand >= 0.5f)
                pattern[i] = true;
            else
                pattern[i] = false;

            patterntext += Translate(pattern[i]) + " ";
        }
        patternText.text = patterntext;
    }

    string Translate(bool value)
    {
        string res = value == true ? "up" : "down";
        return res;
    }
}
