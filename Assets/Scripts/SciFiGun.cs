using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class SciFiGun : MonoBehaviour {

    private Hand hand;
    private SteamVR_Controller.Device controller;

    public GameObject bulletPrefab;
    public Transform shootPosition;

    public float bulletSpeed;

    private AudioSource aSource;

	void Start () {

        hand = GetComponentInParent<Hand>();
        aSource = GetComponent<AudioSource>();
	}
	
	void Update () {

        if (hand.controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        var tmp = Instantiate(bulletPrefab, shootPosition.position, transform.parent.rotation);
        tmp.GetComponent<Rigidbody>().velocity =  transform.forward * bulletSpeed;
        aSource.Play();
    }

}
