using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public Transform[] spawnSpots;
    public float SpawnCountdown;
    public int SpawnTime;
    public float TimeBeforeSpawn;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCountdown = TimeBeforeSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnCountdown <= 0)
        {
            int randPos = Random.Range(0, spawnSpots.Length);
            Instantiate(Enemy, spawnSpots[randPos].position, Quaternion.identity);
            SpawnCountdown = SpawnTime;
        }
        else
        {
            SpawnCountdown -= Time.deltaTime;
        }
    }
}
