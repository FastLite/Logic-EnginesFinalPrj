using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int numberOfTestEnemies = 6;
    public int timeBetweenWave;

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
    }

    private void Update()
    {
        timeUntilNextWaveTMP.text = Mathf.RoundToInt(nextWaveTime - Time.time).ToString();
        for (var i = 0; i < 4; i++)
            if (nextWaveTime < Time.time) //revork into Ienumerator
            {
                GameManager.instance.waveNumber += 1;
                double a = 40 * GameManager.instance.waveNumber * 1.2;
                planet.ChangeMoneyAmount(a);
                SpawnWave(numberOfTestEnemies, sides[m]);
                nextWaveTime += timeBetweenWave;
                m++;
                
                if (m == 3)
                {
                    m = 0;
                    i = 0;  
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

    public void SpawnWave(double numberOfEnemies, string caseName)
    {
        GameManager.instance.waveNumber++;
        Debug.Log(caseName);
        numberOfEnemies = numberOfEnemies * (1.5 * GameManager.instance.waveNumber);
        switch (caseName)
        {
            case "RightSide":
                for (var i = 0; i < numberOfEnemies; i++) SpawnEnemiesAtSide(rightSideCollider);
                break;
            case "LeftSide":
                for (var i = 0; i < numberOfEnemies; i++)
                {
                    SpawnEnemiesAtSide(leftSideCollider);
                }

                break;
            case "BothSides":
                for (var i = 0; i < numberOfEnemies / 2; i++)
                {
                    SpawnEnemiesAtSide(rightSideCollider);
                    SpawnEnemiesAtSide(leftSideCollider);
                }

                break;
        }
    }

    public void SpawnEnemiesAtSide(Collider2D side)
    {
        {
            var rndPoint3D = RandomPointInBounds(side.bounds, 1f);
            var rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
            var rndPointInside = side.ClosestPoint(new Vector2(rndPoint2D.x, rndPoint2D.y));
            if (rndPointInside.x == rndPoint2D.x && rndPointInside.y == rndPoint2D.y)
            {
                var rot = Quaternion.FromToRotation(Vector3.forward, new Vector3(0, 0, 0));

                var pool = ObjectPooling.instance.GetObject(5);
                pool.SetActive(true);
                pool.transform.rotation = rot;
                pool.transform.position = rndPoint2D;
            }
        }
    }
}