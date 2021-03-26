using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Vector3 projectileShootFromPos;
    public GameObject currentTarget;

    public float lastFire;
    public float turretFireDelay;
    public float towerDamage;

    public List<GameObject> enemiesInside;


    private void Update()
    {
        if (enemiesInside.Count != 0)
        { 
            float currentTargetDistance = Vector3.Distance(currentTarget.transform.position, transform.position);
            foreach (var enemy in enemiesInside)
            {
                float distance = Vector3.Distance(enemy.transform.position, transform.position);
                if (distance<currentTargetDistance)
                {
                    currentTarget = enemy;
                }

            }
            
            
            if (lastFire + turretFireDelay <= Time.time)
            {
                Projectile.CreateProjectile(transform.position, currentTarget.transform.position, towerDamage);
                lastFire = Time.time;


            }

            
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInside.Add(other.gameObject);
            Debug.Log("Enemy is inside the trigger");
        }

        if (currentTarget ==null)
        {
            currentTarget = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInside.Remove(other.gameObject);
            Debug.Log("Enemy is exited the trigger");
        }    
    }
}
