using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public EnemySO EnemySo;
    public float health = 1;

    private void Awake()
    {
        health = EnemySo.maxHealth;
    }

    private void Update()
    {
        //Move enemy towords the point on the pre determined speed 
        transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(0-EnemySo.stopDistance, 0-EnemySo.stopDistance), EnemySo.speed * Time.deltaTime);
    }

    public void ChangeHealth(float changeValue)
    {
        health += changeValue;
        if (health > EnemySo.maxHealth)
        {
            health = EnemySo.maxHealth;
        }

        if (health<=0)
        {
            gameObject.SetActive(false);
            GameManager.instance.score += EnemySo.score;
            Debug.Log("enemy is dead");
        }
        Debug.Log("Enemy health is " + health);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {    
            ChangeHealth(-other.gameObject.GetComponent<Projectile>().damage);
            //Debug.Log("я в уроне");
            other.gameObject.SetActive(false);
            
        }    
    }
}