using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 20;
    public float damage = 20;
    
    public GameObject target;
    

    public void SetProjectileDamage(float newDamage)
    {
        damage = newDamage;

    }

    private void Update()
    {
        if (!target.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        Vector3 moveDir = (target.transform.position - transform.position).normalized;

        transform.position += moveDir * (moveSpeed * Time.deltaTime);


        
        float n = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        if (n<0)
        {
            n += 360;
        }
        float angle = n;
        
        transform.eulerAngles = new Vector3(0,0,angle);

        
    }
}
