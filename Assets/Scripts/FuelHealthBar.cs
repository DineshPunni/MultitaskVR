using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelHealthBar : MonoBehaviour {

    float maxHealth;
    float currentHealth;

    Slider healthBar;

	void Start ()
    {
        maxHealth = GetComponentInParent<FuelBoxController>().maxHealth;
        healthBar = GetComponent<Slider>();
	}
	
	void Update ()
    {
        currentHealth = GetComponentInParent<FuelBoxController>().currentHealth;
        healthBar.value = currentHealth / maxHealth;
		
	}
}
