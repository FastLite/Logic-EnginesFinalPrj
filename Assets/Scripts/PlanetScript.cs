using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlanetScript : MonoBehaviour
{
    
    public int maxHealth;
    public int health;
    //score is used for internal hard currency calculation and might
    //actually show score in the future
    public int score;
    //Money or resources are used to place turrets
    public int money;
    public float pressTimeCheck;

    //Reference to healthBar script used to display health
    public PlanetHealthBar healthBar;
    
    public GameObject gameOverCanvas;
    
    //references scene manager script and pause the game time on pause
    public UnityEvent endPauseGame;

    public TextMeshProUGUI earnedCurrency;

    public AudioSource musicSource;
    public AudioClip uLoseMusic;

    private void Start()
    {
        //Initialise and display money amunt on UI without hardcoding it
        ChangeMoneyAmount(0);
        
        gameOverCanvas.SetActive(false);
        //Reset health to maximum health
        health = maxHealth;
        score = 0;
        healthBar.SetMaxHelath(maxHealth);
    }

    private void Update()
    {        //Check if the touch was made on UI or not
        if ( !EventSystem.current.IsPointerOverGameObject())
        {
            //Get mouse click position and place tower there
            if (Input.GetMouseButtonDown(0))
            {
                var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var newTower = createTower("1",20).transform;
                //If player can't buy a tower - return 
                if (newTower == null)
                {
                    return;
                }
                newTower.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
            }
            
            //Get touch position and place tower there
            if (Input.touchCount > 0 && Time.time > pressTimeCheck + 0.5)
            {
                var myTouch = Input.GetTouch(0);

                var newTower = createTower("1",20).transform;
                //If player can't buy a tower - return 

                if (newTower == null)
                {
                    return;
                }
                newTower.transform.position = myTouch.position;
                pressTimeCheck = Time.time;
            }
        }       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //If planet collided with enemy or bullet destroy this object and reduce planet's health
        if ( other.gameObject.CompareTag("Enemy"))
        {
            ChangeHealth(-other.gameObject.GetComponent<Enemy>().EnemySo.collisionDamage);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("EnemyBullet") )
        {
            ChangeHealth(-other.gameObject.GetComponent<EnemyBullet>().damage);
            other.gameObject.SetActive(false);
        }        
    }

    public void ChangeHealth(int changeValue)
    {
        //Change health value based on the parameter stated in the enemy or bullet
        health += changeValue;
        if (health > maxHealth) health = maxHealth;
        //Change Health bar value
        healthBar.SetHealth(health);

        if (health <= 0)
        {    //trigger game over 
            score = GameManager.instance.score;
            GameManager.instance.ChangeHardCurrency(Mathf.RoundToInt(score / 100));
            gameOverCanvas.SetActive(true);
            endPauseGame.Invoke();
            Time.timeScale = 0;

            musicSource.clip = uLoseMusic;
            musicSource.Play();
        }
    }

    public GameObject createTower(string type, int cost)
    {   //Check if the player has enough money to place tower
        if (money - cost<0)
        {
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
        earnedCurrency.text = "Resources: " + money;
    }

    //Change max health after upgrade purchase and restore health to it's new maximum
    public void IncreaseMaxHeath(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        health = maxHealth;
        healthBar.SetHealth(maxHealth);
    }    
}