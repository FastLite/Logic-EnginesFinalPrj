using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public int maxHealth;
    public int health;

    //public int armor;

    public GameObject gameOverCanvas;


    private void Start()
    {
        gameOverCanvas.SetActive(false);
        health = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Enemy"))
        {
            ChangeHealth(other.gameObject.GetComponent<Enemy>().EnemySo.collisionDamage);
            
            Destroy(other.gameObject);
            //later change to object pooling
        }

        
    }

    public void ChangeHealth(int changeValue)
    {
        //Change health value based on the parametr stated in the enemy or bullet (not decided yet)
        health += changeValue;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health<=0)
        {
            gameOverCanvas.SetActive(true);
            
            //trigger game over 
        }
    }
}
