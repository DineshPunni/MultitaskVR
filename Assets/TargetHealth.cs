using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetHealth : MonoBehaviour {

    public static Action OnTargetDestroyed;
   
    public int health;

    int fullHealth;


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
        health = fullHealth;
    }

    void Start () {

        fullHealth = health;
	}
	
	void Update () {
		
	}


    public void TakeDamage(int number)
    {
        health--;

        if(health == 0)
        {
            if (OnTargetDestroyed != null)
                OnTargetDestroyed();
        }
    }
}
