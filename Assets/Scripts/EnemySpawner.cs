using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public int numberOfTestEnemies = 6;
    
    public GameObject area1;
    public GameObject area2;


    private void Start()
    {
        Collider2D area1Collider = area1.GetComponent<Collider2D>();
        Collider2D area2Collider = area2.GetComponent<Collider2D>();
        for (int i = 0; i < numberOfTestEnemies/2; i++)
        {
            {
                Vector3 rndPoint3D = RandomPointInBounds(area1Collider.bounds, 1f);
                Vector2 rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
                Vector2 rndPointInside = area1Collider.ClosestPoint(new Vector2(rndPoint2D.x, rndPoint2D.y));
                if (rndPointInside.x == rndPoint2D.x && rndPointInside.y == rndPoint2D.y)
                {
                    Quaternion rot = Quaternion.FromToRotation(Vector3.forward, new Vector3(0, 0, 0));

                    GameObject pool = ObjectPooling.instance.GetObject(5);
                    pool.SetActive(true);
                    pool.transform.rotation = rot;
                    pool.transform.position = rndPoint2D;
                    
                }


            }
        }
        for (int i = 0; i < numberOfTestEnemies/2; i++)
        {
            {
                Vector3 rndPoint3D = RandomPointInBounds(area2Collider.bounds, 1f);
                Vector2 rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
                Vector2 rndPointInside = area2Collider.ClosestPoint(new Vector2(rndPoint2D.x, rndPoint2D.y));
                if (rndPointInside.x == rndPoint2D.x && rndPointInside.y == rndPoint2D.y)
                {
                    Quaternion rot = Quaternion.FromToRotation(Vector3.forward, new Vector3(0, 0, 0));

                    GameObject pool = ObjectPooling.instance.GetObject(5);
                    pool.SetActive(true);
                    pool.transform.rotation = rot;
                    pool.transform.position = rndPoint2D;
                    
                }


            }
        }
    }

    private Vector3 RandomPointInBounds(Bounds bounds, float scale)
        {
            return new Vector3(
                Random.Range(bounds.min.x * scale, bounds.max.x * scale),
                Random.Range(bounds.min.y * scale, bounds.max.y * scale),
                Random.Range(bounds.min.z * scale, bounds.max.z * scale)
            );
        }
}
