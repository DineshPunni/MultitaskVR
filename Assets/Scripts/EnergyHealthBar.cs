using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyHealthBar : MonoBehaviour {

    float maxHealth;
    float currentHealth;

    Slider healthBar;

    void Start ()
    {
        maxHealth = GetComponentInParent<EnergyBoxController>().maxHealth;
        healthBar = GetComponent<Slider>();
	}
	
	void Update ()
    {
        currentHealth = GetComponentInParent<EnergyBoxController>().currentHealth;
        healthBar.value = currentHealth / maxHealth;

    }
}
