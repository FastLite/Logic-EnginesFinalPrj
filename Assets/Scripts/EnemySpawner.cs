using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Setting basing number which will be scaled by wave number and coefficient 
    public int baseEnemiesNumber = 6;
    //Custom Time which will launch big waves of enemies
    public int timeBetweenWave;
    public TextMeshProUGUI timeUntilNextWaveTMP;
    //Right Spawn Area
    public GameObject right;
    //Left Spawn Area
    public GameObject left;

    public List<string> sides;
    
    //Current side. 0 = right 1 = Left
    private int m = 0;
    private float nextWaveTime;
    private Collider2D leftSideCollider;

    private Collider2D rightSideCollider;
    //Reference to the main planet script to give player money at the start of each wave
    private PlanetScript planet;

    private void Start()
    {    //Get colliders from the represented game objects
        rightSideCollider = right.GetComponent<Collider2D>();
        leftSideCollider = left.GetComponent<Collider2D>();
        
        nextWaveTime = timeBetweenWave;
        planet = FindObjectOfType<PlanetScript>();
        //Launch first wave in "TimeBetweenWaves" seconds
        StartCoroutine("LaunchWave");
        
        timeUntilNextWaveTMP.text = "";
    }
    
    //Get random position within spawning areas
    private Vector3 RandomPointInBounds(Bounds bounds, float scale)
    {
        return new Vector3(
            Random.Range(bounds.min.x * scale, bounds.max.x * scale),
            Random.Range(bounds.min.y * scale, bounds.max.y * scale),
            Random.Range(bounds.min.z * scale, bounds.max.z * scale));
    }

    
    public void SpawnWave(double numberOfEnemies, string caseName)
    {
        //Increase current wave number
        GameManager.instance.waveNumber++;
        //Multiply number on the current wave number and add additional coeficient
        numberOfEnemies = numberOfEnemies * (1.5 * GameManager.instance.waveNumber);
        //Chose sides based on the "m" as index in the string list
        switch (caseName)
        {
            case "RightSide":
                for (var i = 0; i < numberOfEnemies/ 2; i++)
                {
                    SpawnEnemiesAtSide(rightSideCollider,3);
                }
                for (var i = 0; i < numberOfEnemies/2; i++)
                {
                    SpawnEnemiesAtSide(rightSideCollider,4);
                }
                break;
            case "LeftSide":
                for (var i = 0; i < numberOfEnemies/ 2 ; i++)
                {
                    SpawnEnemiesAtSide(leftSideCollider,3);
                }
                for (var i = 0; i < numberOfEnemies/2; i++)
                {
                    SpawnEnemiesAtSide(leftSideCollider,4);
                }

                break;
            case "BothSides":
                for (var i = 0; i < numberOfEnemies / 2/2; i++)
                {
                    SpawnEnemiesAtSide(rightSideCollider,3);
                    SpawnEnemiesAtSide(leftSideCollider,3);
                }
                for (var i = 0; i < numberOfEnemies / 4/2; i++)
                {
                    SpawnEnemiesAtSide(rightSideCollider,4);
                    SpawnEnemiesAtSide(leftSideCollider,4);
                }
                for (var i = 0; i < Mathf.RoundToInt((float)numberOfEnemies / 10); i++)
                {
                    SpawnEnemiesAtSide(rightSideCollider,5);
                    SpawnEnemiesAtSide(leftSideCollider,5);
                }

                break;
        }
    }

    //Change transform of needed enemies to the random position 
    public void SpawnEnemiesAtSide(Collider2D side, int type)
    {
        {
            var rndPoint3D = RandomPointInBounds(side.bounds, 1f);
            var rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
            var rndPointInside = side.ClosestPoint(new Vector2(rndPoint2D.x, rndPoint2D.y));
            if (rndPointInside.x == rndPoint2D.x && rndPointInside.y == rndPoint2D.y)
            {
                var rot = Quaternion.FromToRotation(Vector3.forward, new Vector3(0, 0, 0));
                //Spawn specifically selected enemy type
                var pool = ObjectPooling.instance.GetObject(type);
                pool.SetActive(true);
                pool.transform.rotation = rot;
                pool.transform.position = rndPoint2D;
                
                
            }
        }
    }

    private IEnumerator LaunchWave()
    {
        //Wait for the delay
        yield return new WaitForSeconds(timeBetweenWave);
            GameManager.instance.waveNumber += 1;
            
            //add money to the player
            double a = 15 * GameManager.instance.waveNumber;
            planet.ChangeMoneyAmount(a);
            
            //Increase current run score
            GameManager.instance.ChangeScore(Mathf.RoundToInt((float)a));
            
            //and start spawning enemies
            SpawnWave(baseEnemiesNumber, sides[m]);
            nextWaveTime += timeBetweenWave;
            m++;
            //Reset m if enemies were spawn at each of the sides and in the middle
            if (m == 3)
                m = 0;
            //Begin next countdown until wave
            StartCoroutine("LaunchWave");
            
    }
}