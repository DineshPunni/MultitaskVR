using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Holder : MonoBehaviour {


    public GameObject batteryChargingPrefab;
    public GameObject batteryEmptyPrefab;

    GameObject chargingBattery;
    GameObject emptyBattery;
    private bool isFull;


    private void OnEnable()
    {
        BatteryCharging.OnBatteryEmpty += (battery) => ChangeBattery(battery);
    }

    private void OnDisable()
    {
        BatteryCharging.OnBatteryEmpty -= (battery) => ChangeBattery(battery);

    }


    void ChangeBattery(GameObject battery)
    {
        if (battery.transform.parent == transform)
        {

            Destroy(chargingBattery);

            emptyBattery = Instantiate(batteryEmptyPrefab);
            emptyBattery.transform.SetParent(transform);
            emptyBattery.transform.localPosition = new Vector3(0, 0, 1);
        }
    }

    void Start () {
		
	}
	
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BatteryFull" && !isFull)
        {
            if(other.GetComponentInParent<Hand>() !=null)
                other.GetComponentInParent<Hand>().DetachObject(other.gameObject, false);
            isFull = true;
            Destroy(other.gameObject);        
            ChargeBattery();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("something left");

        if(other.gameObject.tag == "Battery" && isFull)
        {
            isFull = false;
            Debug.Log("there is space again");
        }
    }

    void ChargeBattery()
    {
        chargingBattery = Instantiate(batteryChargingPrefab, new Vector3(0, 0, 4), Quaternion.identity);
        chargingBattery.transform.SetParent(transform);
        chargingBattery.transform.localPosition = new Vector3(0, 0, 1);
    }

}


