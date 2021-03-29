using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public int maxHealth;
    public int health;

    //public int armor;

    public GameObject gameOverCanvas;

    public TextMeshProUGUI score;
    public TextMeshProUGUI earnedCurrency;
    

    private void Start()
    {
        gameOverCanvas.SetActive(false);
        health = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("Enemy"))
        {
            ChangeHealth(-other.gameObject.GetComponent<Enemy>().EnemySo.collisionDamage);
            
            other.gameObject.SetActive(false);
            
            Debug.Log("Planet health is now " + health);
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
