using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    private void OnEnable()
    {
        TargetHealth.OnTargetDestroyed += GameOver;
    }

    private void OnDisable()
    {
        TargetHealth.OnTargetDestroyed -= GameOver;

    }

    void GameOver()
    {
        Debug.Log("Game Over");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



}
