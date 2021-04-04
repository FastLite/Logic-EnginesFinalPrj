using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;


    public List<GameObject> allCreatedBullets = new List<GameObject>();
    public GameObject bullet;

    public List<GameObject> allCreatedTurretBullets = new List<GameObject>();
    public GameObject bulletTurret;

    public List<GameObject> allEnemyArtillery = new List<GameObject>();
    public GameObject enemyArtillery;

    public List<GameObject> allEnemyRange = new List<GameObject>();
    public GameObject enemyRange;

    public List<GameObject> allEnemyMelee = new List<GameObject>();
    public GameObject enemyMelee;


    public List<GameObject> allTurret1 = new List<GameObject>();
    public GameObject turret1;


    public int eachObjectToCreate = 3;

    public List<string> objectsToInitialize;

    private void Awake()
    {
        instance = this;

        foreach (var VARIABLE in objectsToInitialize)
            for (var i = 0; i < eachObjectToCreate; i++)
                CreatePoolingObject(VARIABLE);
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
                allCreatedTurretBullets.Add(go);
                break;
            case "enemyArtillery":
                go = Instantiate(enemyArtillery);
                allEnemyArtillery.Add(go);
                break;
            case "enemyRange":
                go = Instantiate(enemyRange);
                allEnemyRange.Add(go);
                break;
            case "enemyMelee":
                go = Instantiate(enemyMelee);
                allEnemyMelee.Add(go);
                break;
            case "turret1":
                go = Instantiate(turret1);
                allTurret1.Add(go);
                break;
            default:
                Debug.LogError(
                    "There is no such object you want to create. Check your spelling or redact [ObjectPooling] script ");
                return;
        }

        go.SetActive(false);
    }


    // 1-bullets, 2-turret bullets, 3-artillery enemy, 4-range enemy, 5-melee enemy
    public GameObject GetObject(int caseNumber)
    {
        if (caseNumber == 1)
        {
            foreach (var t in allCreatedBullets)
                if (!t.activeInHierarchy)
                    return t;

            var go = Instantiate(bullet);
            go.SetActive(false);
            allCreatedBullets.Add(go);
            return go;
        }

        if (caseNumber == 2)
        {
            foreach (var t in allCreatedTurretBullets)
                if (!t.activeInHierarchy)
                    return t;

            var go = Instantiate(bulletTurret);
            go.SetActive(false);
            allCreatedTurretBullets.Add(go);
            return go;
        }

        if (caseNumber == 3)
        {
            foreach (var t in allEnemyArtillery)
                if (!t.activeInHierarchy)
                    return t;

            var go = Instantiate(enemyArtillery);
            go.SetActive(false);
            allEnemyArtillery.Add(go);
            return go;
        }

        if (caseNumber == 4)
        {
            foreach (var t in allEnemyRange)
                if (!t.activeInHierarchy)
                    return t;

            var go = Instantiate(enemyRange);
            go.SetActive(false);
            allEnemyRange.Add(go);
            return go;
        }

        if (caseNumber == 5)
        {
            foreach (var t in allEnemyMelee)
                if (!t.activeInHierarchy)
                    return t;
            var go = Instantiate(enemyMelee);
            go.SetActive(false);
            allEnemyMelee.Add(go);
            return go;
        }

        if (caseNumber == 6)
        {
            foreach (var t in allTurret1)
                if (!t.activeInHierarchy)

                    return t;
            var go = Instantiate(turret1);
            go.SetActive(false);
            allTurret1.Add(go);
            return go;
        }

        Debug.LogError("There is no such object in the pool");
        return null;
    }
}