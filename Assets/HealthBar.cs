﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    float maxHealth;
    float currentHealth;

    Slider healthBar;

	void Start () {

        maxHealth = GetComponentInParent<TargetController>().maxHealth;
        healthBar = GetComponent<Slider>();
	}
	
	void Update () {

        currentHealth = GetComponentInParent<TargetController>().currentHealth;
        healthBar.value = currentHealth / maxHealth;
    }

}
