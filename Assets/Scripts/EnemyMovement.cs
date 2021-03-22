using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    
    
 
    void Update()
    {
        
        //Move enemy towords the point on the pre determined speed 
        transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(0, 0), speed * Time.deltaTime);
    }
}
