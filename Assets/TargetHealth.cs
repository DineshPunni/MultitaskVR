using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetHealth : MonoBehaviour {

    public static Action OnTargetDestroyed;


    public int health;

	void Start () {
		
	}
	
	void Update () {
		
	}


    public void TakeDamage(int number)
    {
        health--;

        if(health <= 0)
        {
            if (OnTargetDestroyed != null)
                OnTargetDestroyed();
        }
    }
}
