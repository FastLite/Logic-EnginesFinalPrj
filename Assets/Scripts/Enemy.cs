using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public EnemySO EnemySo;
    public int health = 1;


    private void Update()
    {
        //Move enemy towords the point on the pre determined speed 
        transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(0, 0), EnemySo.speed * Time.deltaTime);
    }

    public void ChangeHealth(int changeValue)
    {
        health += changeValue;
        if (health > EnemySo.maxHealth)
        {
            health = EnemySo.maxHealth;
        }
    }
}
