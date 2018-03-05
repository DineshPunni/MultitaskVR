using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetController : MonoBehaviour {

    public static Action OnTargetDestroyed;

    [Header("Balancing")]
    [HideInInspector]
    public float currentHealth;
    public float maxHealth;
    public float healthReg;
    bool isAlive = true;

   
    private void OnEnable()
    {
        GameManager.OnStartGame += StartGame;
    }


    private void OnDisable()
    {
        GameManager.OnStartGame -= StartGame;
    }


    void Update()
    {
        if (currentHealth <= maxHealth && isAlive)
            currentHealth += Time.deltaTime * healthReg;
    }


    void StartGame()
    {
        isAlive = true;
        currentHealth = maxHealth;
    }


    public void TakeDamage(float damageAmount)
    {
        currentHealth-= damageAmount;

        if(currentHealth <= 0)
        {
            if (OnTargetDestroyed != null && isAlive)
            {
                isAlive = false;
                OnTargetDestroyed();
            }
        }
    }
}
