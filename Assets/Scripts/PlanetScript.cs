using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlanetScript : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int score;
    public int money;

    //public int armor;

    public GameObject gameOverCanvas;
    public UnityEvent endPauseGame;

    public TextMeshProUGUI earnedCurrency;

    public AudioSource musicSource;
    //public AudioSource sfxSource;
    public AudioClip uLoseMusic;

    private void Start()
    {
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
        health = maxHealth;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Transform newTower =  createTower("1").transform;
            newTower.transform.position = new Vector3(worldPosition.x,worldPosition.y,0);
            
        }   
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
            endPauseGame.Invoke();
            Time.timeScale = 0;

            musicSource.clip = uLoseMusic;
            musicSource.Play();

            //trigger game over 
        }
    }

    public GameObject createTower(string type)
    {
        GameObject turret = ObjectPooling.instance.GetObject(6);
        turret.SetActive(true);
        money -= 20;
        return turret;
    }
}