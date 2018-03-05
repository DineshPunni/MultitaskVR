using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BatteryCharging : MonoBehaviour {


    public static Action<GameObject> OnBatteryEmpty;

    [Header("Balancing")]
    float chargeTimeBattery;

    


    private void OnEnable()
    {
        Invoke("BatteryEmpty", 5f);
    }


    void BatteryEmpty()
    {

        if (OnBatteryEmpty != null)
            OnBatteryEmpty(gameObject);
    }

}
