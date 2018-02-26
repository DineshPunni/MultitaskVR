using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryManager : MonoBehaviour {

    public GameObject batteryPrefab;
    public Transform batterySpawnPos;

    public float spawnFrequency;


    private void OnEnable()
    {
        GameManager.OnStartGame += StartSpawning;
        GameManager.OnGameOver += EndSpawning;
    }

    private void OnDisable()
    {
        GameManager.OnStartGame -= StartSpawning;
        GameManager.OnGameOver -= EndSpawning;
    }


    void StartSpawning ()
    {
        InvokeRepeating("SpawnBattery", 5, spawnFrequency);
	}


    void EndSpawning()
    {
        CancelInvoke();
    }


    void SpawnBattery()
    {
        Instantiate(batteryPrefab, batterySpawnPos.position, Quaternion.Euler(45,63,25));
    }

}
