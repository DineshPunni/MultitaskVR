using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    public int health;
    public int attackDamage;
    public float moveSpeed;
    public float attackSpeed;

    bool arrived;

    private GameObject target;


    private Animator aTor;

    void Start()
    {
        aTor = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Target");
        transform.LookAt(target.transform);
    }


    void Update()
    {
        if (!arrived)
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
       
    }


    void Attack()
    {
        target.GetComponent<TargetHealth>().TakeDamage(attackDamage);
        aTor.SetBool("arrived", true);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            DamageTaken();
        }

        if (coll.gameObject.tag == "Target")
        {
            arrived = true;
            InvokeRepeating("Attack", 0, attackSpeed);
        }
    }


    void DamageTaken()
    {
        health--;

        if (health <= 0)
            Dead();
    }

    private void Teleport()
    {
        arrived = false;

        float newXPos = UnityEngine.Random.Range(-3, 3);
        float newZPos = UnityEngine.Random.Range(3, 7);
        transform.position = new Vector3(newXPos, 0, newZPos);
    }

    void Dead()
    {
        arrived = true;
        aTor.SetTrigger("dead");
        Destroy(gameObject, 1f);
    }
}
