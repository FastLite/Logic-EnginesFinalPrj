using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;

    public GameObject bullet;
    public List<GameObject> allCreatedBullets = new List<GameObject>();

    public GameObject bulletTurret;
    public List<GameObject> allCreatedTurretBullets = new List<GameObject>();

    public GameObject enemyArtillery;
    public List<GameObject> allEnemyArtillery = new List<GameObject>();

    public GameObject enemyRange;
    public List<GameObject> allEnemyRange = new List<GameObject>();

    public GameObject enemyMelee;
    public List<GameObject> allEnemyMelee = new List<GameObject>();

    public int eachObjectToCreate = 3;

    public List<string> objectsToInitialize;
    
    
    public GameObject projectile1;

    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        foreach (var VARIABLE in objectsToInitialize)
        {
            for (int i = 0; i < eachObjectToCreate ; i++)
            {
                CreatePoolingObject(VARIABLE);
            }
        }
        
        
            
        
    }

    public void CreatePoolingObject(string objectToCreate)
    {
        GameObject go;

        switch (objectToCreate)
        {
            case "bullet":
                go = Instantiate(bullet);
                allCreatedBullets.Add(go);
                break;
            case "bulletTurret":
                go = Instantiate(bulletTurret);
                allCreatedBullets.Add(go);
                break;
            case "enemyArtillery":
                go = Instantiate(enemyArtillery);
                allCreatedBullets.Add(go);
                break;
            case "enemyRange":
                go = Instantiate(enemyRange);
                allCreatedBullets.Add(go);
                break;
            case "enemyMelee":
                go = Instantiate(enemyMelee);
                allCreatedBullets.Add(go);
                break;
            default:
                Debug.Log("There is no such object you want to create. Check your spelling or redact [ObjectPooling] script ");
                return;
        }
        
        go.SetActive(false);
        
    }

    public GameObject GetObject(string objectToCreate)
    {
        
        
        switch (objectToCreate)
        {
            case "bullet":
                foreach (var t in allCreatedBullets)
                {
                    if (t.activeInHierarchy)
                    {
                        return t;
                    }
                }
                break;
            case "bulletTurret":
                foreach (var t in allCreatedBullets)
                {
                    if (t.activeInHierarchy)
                    {
                        return t;
                    }
                }
                break;
            case "enemyArtillery":
                foreach (var t in allCreatedBullets)
                {
                    if (t.activeInHierarchy)
                    {
                        return t;
                    }
                }
                break;
            case "enemyRange":
                foreach (var t in allCreatedBullets)
                {
                    if (t.activeInHierarchy)
                    {
                        return t;
                    }
                }
                break;
            case "enemyMelee":
                foreach (var t in allEnemyMelee)
                {
                    if (t.activeInHierarchy)
                    {
                        return t;
                    }
                }
                break;
            
        }

        GameObject go = Instantiate(bullet);
        go.SetActive(false);
        allCreatedBullets.Add(go);
        return go;
    }
}
