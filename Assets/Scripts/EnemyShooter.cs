using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public EnemySO type;
    public int delay;
    public float lastFire;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (lastFire + delay <= Time.time)
            {
                
                GameObject newBullet = ObjectPooling.instance.GetObject(1);
                newBullet.transform.position = gameObject.transform.position;
                newBullet.gameObject.SetActive(true);
                lastFire = Time.time;
                Quaternion rotation = Quaternion.LookRotation (new Vector3(0,0,0) - transform.position, transform.TransformDirection(Vector3.up));
                transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            }
        }
    }

    
    
}
