using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIShootable : MonoBehaviour {

    public UnityEvent OnButtonShot;
   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            OnButtonShot.Invoke();
        }
    }
}


