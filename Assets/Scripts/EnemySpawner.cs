using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int baseEnemiesNumber = 6;
    public int timeBetweenWave;
    public int killedEnemies;

    public TextMeshProUGUI timeUntilNextWaveTMP;

    public GameObject right;
    public GameObject left;

    public List<string> sides;
    private Collider2D leftSideCollider;
    private int m = 0;
    private float nextWaveTime;
    private Collider2D rightSideCollider;

    private PlanetScript planet;

    private void Start()
    {
        rightSideCollider = right.GetComponent<Collider2D>();
        leftSideCollider = left.GetComponent<Collider2D>();

        nextWaveTime = timeBetweenWave;
        planet = FindObjectOfType<PlanetScript>();

        StartCoroutine("LaunchWave");
    }

    private void Update()
    {
        timeUntilNextWaveTMP.text = Mathf.RoundToInt(nextWaveTime - Time.time).ToString();
       
    }


    private Vector3 RandomPointInBounds(Bounds bounds, float scale)
    {
        return new Vector3(
            Random.Range(bounds.min.x * scale, bounds.max.x * scale),
            Random.Range(bounds.min.y * scale, bounds.max.y * scale),
            Random.Range(bounds.min.z * scale, bounds.max.z * scale));
    }

    public void SpawnWave(double numberOfEnemies, string caseName)
    {
        GameManager.instance.waveNumber++;
        Debug.Log(caseName);
        numberOfEnemies = numberOfEnemies * (1.5 * GameManager.instance.waveNumber);
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

    public void SpawnEnemiesAtSide(Collider2D side, int type)
    {
        {
            var rndPoint3D = RandomPointInBounds(side.bounds, 1f);
            var rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
            var rndPointInside = side.ClosestPoint(new Vector2(rndPoint2D.x, rndPoint2D.y));
            if (rndPointInside.x == rndPoint2D.x && rndPointInside.y == rndPoint2D.y)
            {
                var rot = Quaternion.FromToRotation(Vector3.forward, new Vector3(0, 0, 0));

                
                var pool = ObjectPooling.instance.GetObject(type);
                pool.SetActive(true);
                pool.transform.rotation = rot;
                pool.transform.position = rndPoint2D;
                
                
            }
        }
    }

    private IEnumerator LaunchWave()
    {
        yield return new WaitForSeconds(timeBetweenWave);
            GameManager.instance.waveNumber += 1;
            double a = 40 * GameManager.instance.waveNumber * 1.2;
            planet.ChangeMoneyAmount(a);
            GameManager.instance.ChangeScore(Mathf.RoundToInt((float)a));
            SpawnWave(baseEnemiesNumber, sides[m]);
            nextWaveTime += timeBetweenWave;
            m++;

            if (m == 3)
                m = 0;
            StartCoroutine("LaunchWave");
            
    }
}