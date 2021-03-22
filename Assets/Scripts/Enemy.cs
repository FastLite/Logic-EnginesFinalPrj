using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    public int health = 1;
    public int maxHealth = 1;


    public void ChangeHealth(int changeValue)
    {
        health += changeValue;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
