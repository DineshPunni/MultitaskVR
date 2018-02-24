using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    float maxHealth;
    float currentHealth;
    float lifeRegSpeed = 1;

    Slider healthBar;

	void Start () {

        maxHealth = GetComponentInParent<TargetHealth>().maxHealth;
        healthBar = GetComponent<Slider>();
	}
	
	void Update () {

        currentHealth = GetComponentInParent<TargetHealth>().currentHealth;
        healthBar.value = currentHealth / maxHealth;
    }

}
