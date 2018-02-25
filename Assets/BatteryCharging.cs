using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BatteryCharging : MonoBehaviour {


    public static Action<GameObject> OnBatteryEmpty;

	// Use this for initialization
	void Start () {



    }

    // Update is called once per frame
    void Update () {
		
	}


    private void OnEnable()
    {
        Invoke("BatteryEmpty", 5);
    }


    void BatteryEmpty()
    {
        GetComponent<Renderer>().material.color = Color.red;

        if (OnBatteryEmpty != null)
            OnBatteryEmpty(gameObject);
    }

}
