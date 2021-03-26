using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 20;
    public float damage = 20;

    public static void CreateProjectile(Vector3 spawnPos, Vector3 targetPos, float _damage)
    {
        Transform projectileTransform =  Instantiate(ObjectPooling.instance.projectile1, spawnPos, quaternion.identity).transform;

        Projectile projectile = projectileTransform.GetComponent<Projectile>();
        projectile.Setup(targetPos);
        projectile.SetProjectileDamage(_damage);

    }

    private Vector3 targetPosition;

    private void Setup(Vector3 targetPos)
    { 
        targetPosition = targetPos;
    }

    public void SetProjectileDamage(float newDamage)
    {
        damage = newDamage;

    }

    private void Update()
    {
        Vector3 moveDir = (targetPosition - transform.position).normalized;

        transform.position += moveDir * (moveSpeed * Time.deltaTime);


        
        float n = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        if (n<0)
        {
            n += 360;
        }
        float angle = n;
        
        transform.eulerAngles = new Vector3(0,0,angle);

        if (Vector3.Distance(transform.position,targetPosition)< 1) //replace this code with collision check on enemy
        {
            gameObject.SetActive(false);
        }
    }
}
