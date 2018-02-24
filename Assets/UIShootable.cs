using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIShootable : MonoBehaviour {


    public UnityEvent OnButtonShot;
   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("bb");

        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("aaaa");
            OnButtonShot.Invoke();
        }
    }
}
