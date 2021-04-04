﻿using TMPro;
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
    public TextMeshProUGUI finalScore;

    public AudioSource musicSource;

    //public AudioSource sfxSource;
    public AudioClip uLoseMusic;

    private void Start()
    {
        ChangeMoneyAmount(0);
        gameOverCanvas.SetActive(false);
        health = maxHealth;
        score = 0;
    }

    private void Update()
    {
        
        
        #if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var newTower = createTower("1",20).transform;
                if (newTower == null)
                {
                    return;
                }
                newTower.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
            }
        #endif
        if (Input.touchCount > 0)
        {
            var myTouch = Input.GetTouch(0);

            var newTower = createTower("1",20).transform;
            if (newTower == null)
            {
                return;
            }
            newTower.transform.position = myTouch.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("Enemy"))
        {
            ChangeHealth(-other.gameObject.GetComponent<Enemy>().EnemySo.collisionDamage);

            other.gameObject.SetActive(false);

        }
    }

    public void ChangeHealth(int changeValue)
    {
        //Change health value based on the parameter stated in the enemy or bullet (not decided yet)
        health += changeValue;
        if (health > maxHealth) health = maxHealth;
        if (health <= 0)
        {    //trigger game over 
            score = GameManager.instance.score;
            GameManager.instance.ChangeHardCurrency(Mathf.RoundToInt(score / 100));
            finalScore.text = "Your final score is: "+ score;
            gameOverCanvas.SetActive(true);
            endPauseGame.Invoke();
            Time.timeScale = 0;

            musicSource.clip = uLoseMusic;
            musicSource.Play();

        }
    }

    public GameObject createTower(string type, int cost)
    {
        
        if (money - cost<0)
        {
            Debug.Log("you have no money");
            
            return null;
        }
        ChangeMoneyAmount(-cost);
        var turret = ObjectPooling.instance.GetObject(6);
        turret.SetActive(true);
        
        return turret;
    }

    public void ChangeMoneyAmount(double amount)
    {
        int n = Mathf.RoundToInt((float)amount);
        money += n;
        earnedCurrency.text = money.ToString();
    }
    public void ChangeScore(int amount)
    {
        
        score += amount;
    }
}