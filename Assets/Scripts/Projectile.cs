using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 20;
    public float damage = 20;
    
    //Target gameobject bullet will travel to after release
    public GameObject target;
    

    //Set damage of the projectile based on the tower it was launched from
    public void SetProjectileDamage(float newDamage)
    {
        damage = newDamage;
    }

    private void Update()
    {
        //If target is already destroyed turn off the bullet
         if (!target.activeInHierarchy )
         {
             gameObject.SetActive(false);
         }
         //move towards target
         Vector3 moveDir = (target.transform.position - transform.position).normalized;

         transform.position += moveDir * (moveSpeed * Time.deltaTime);
         
         //Rotate bullet towards the target 
         float n = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
         if (n<0)
         {
             n += 360;
         }
         float angle = n;
        
         transform.eulerAngles = new Vector3(0,0,angle);

        
    }
}