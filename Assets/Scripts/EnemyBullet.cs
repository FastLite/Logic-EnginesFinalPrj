using UnityEngine;







//                                                            //

//                SCRIPT IS NOT USED IN FINAL GAMEPLAY                //

//                                                            //






public class EnemyBullet : MonoBehaviour
{
    public int damage = 10;
    private void Update()
    {
        Vector3 moveDir = (new Vector3(0,0,0) - transform.position).normalized;

        transform.position += moveDir * (10 * Time.deltaTime);

        float n = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        if (n<0)
        {
            n += 360;
        }
        float angle = n;
        
        transform.eulerAngles = new Vector3(0,0,angle);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<PlanetScript>().ChangeHealth(damage);
            gameObject.SetActive(false);
        }
    }
}
