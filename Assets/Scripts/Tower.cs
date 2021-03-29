using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject currentTarget;

    public float lastFire;
    public float turretFireDelay;
    public float towerDamage;

    public List<GameObject> enemiesInside;


    private void Update()
    {
        if (enemiesInside.Count != 0)
        {
            if (enemiesInside.Count ==1)
            {
                currentTarget = enemiesInside[0];
            }
            
            float currentTargetDistance = Vector3.Distance(currentTarget.transform.position, transform.position);
            foreach (var enemy in enemiesInside)
            {
                float distance = Vector3.Distance(enemy.transform.position, transform.position);
                if (distance<currentTargetDistance && currentTarget!=null)
                {
                    currentTarget = enemy;
                }
                

            }
            
            
            
            if (lastFire + turretFireDelay <= Time.time)
            {
                
                GameObject newBullet = ObjectPooling.instance.GetObject(2);
                newBullet.transform.position = gameObject.transform.position;
                newBullet.gameObject.SetActive(true);
                newBullet.gameObject.GetComponent<Projectile>().SetProjectileDamage(towerDamage);
                newBullet.gameObject.GetComponent<Projectile>().target = currentTarget;
                lastFire = Time.time;


            }

            
        }
        else if (currentTarget!=null)
        {
            currentTarget = null;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInside.Add(other.gameObject);
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