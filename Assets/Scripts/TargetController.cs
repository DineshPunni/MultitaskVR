using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetController : MonoBehaviour {

    public static Action OnTargetDestroyed;
   
    public float currentHealth;

    public float maxHealth;

    bool isAlive = true;


    private void OnEnable()
    {
        GameManager.OnStartGame += ResetHealth;
    }

    private void OnDisable()
    {
        GameManager.OnStartGame -= ResetHealth;
    }

    void ResetHealth()
    {
        isAlive = true;
        currentHealth = maxHealth;
    }

    void Start ()
    {

        maxHealth = currentHealth;
	}
	
	void Update ()
    {

        if (currentHealth <= maxHealth && isAlive)
            currentHealth += Time.deltaTime * 0.1f;
	}


    public void TakeDamage(int number)
    {
        currentHealth--;

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
