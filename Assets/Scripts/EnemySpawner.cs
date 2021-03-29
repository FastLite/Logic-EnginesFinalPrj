using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public int numberOfTestEnemies = 6;
    public int timeBetweenWave;
    private float nextWaveTime;
    private int m = 0;

    public TextMeshProUGUI timeUntilNextWaveTMP;
    
    public GameObject right;
    public GameObject left;
    private Collider2D rightSideCollider;
    private Collider2D leftSideCollider;
    
    public List<string> sides;

    private void Start()
    {
        rightSideCollider = right.GetComponent<Collider2D>();
        leftSideCollider = left.GetComponent<Collider2D>();
        
        nextWaveTime = timeBetweenWave;
    }

    private void Update()
    {
        timeUntilNextWaveTMP.text = Mathf.RoundToInt((nextWaveTime - Time.time)).ToString();
        for (int i = 0; i < sides.Count;i++ )
        {
            if (nextWaveTime<Time.time) //revork into Ienumerator
            {
                GameManager.instance.waveNumber += 1;
                SpawnWave(numberOfTestEnemies, sides[m]);
                nextWaveTime += timeBetweenWave;
                
                if (i==2)
                {
                    m = 0;
                    i = 0;
                }

                
            }
            

            
        }
        
    }


    private Vector3 RandomPointInBounds(Bounds bounds, float scale)
    {
        return new Vector3(
            Random.Range(bounds.min.x * scale, bounds.max.x * scale),
            Random.Range(bounds.min.y * scale, bounds.max.y * scale),
            Random.Range(bounds.min.z * scale, bounds.max.z * scale));
    }

    public void SpawnWave(int numberOfEnemies, string caseName)
    {
        switch (caseName)
        {
            case "RightSide":
                for (int i = 0; i < numberOfEnemies; i++)
                {
                    SpawnEnemiesAtSide(rightSideCollider);
                }
                break;
            case "LeftSide":
                for (int i = 0; i < numberOfEnemies; i++)
                {
                    {
                        SpawnEnemiesAtSide(leftSideCollider);
                    }
                }
                break;
            case "BothSides":
                for (int i = 0; i < numberOfEnemies/2; i++)
                {
                    {
                        SpawnEnemiesAtSide(rightSideCollider);
                        SpawnEnemiesAtSide(leftSideCollider);
                    }
                }
                break;
                
        }
    }

    public void SpawnEnemiesAtSide(Collider2D side)
    {
        {
            Vector3 rndPoint3D = RandomPointInBounds(side.bounds, 1f);
            Vector2 rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
            Vector2 rndPointInside = side.ClosestPoint(new Vector2(rndPoint2D.x, rndPoint2D.y));
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