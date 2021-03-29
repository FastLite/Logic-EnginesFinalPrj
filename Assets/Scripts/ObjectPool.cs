using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    public GameObject bullet;
    public int bulletSpawnAmount;
    public List<GameObject> allBulletsCreated = new List<GameObject>();


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // The pool size for the bullets requested at start
        for(int i = 0; i < bulletSpawnAmount; i++)
        {
            CreateBullet();
        }
    }

    public void CreateBullet()
    {
        GameObject go = Instantiate(bullet);
        go.SetActive(false);
        allBulletsCreated.Add(go);
    }

    public GameObject GetBullet()
    {
        // For all the bullets in my list of bullets created
        for(int i = 0; i < allBulletsCreated.Count; i++)
        {
            // if a bullet is inactive in the heirarchy
            if(!allBulletsCreated[i].activeInHierarchy)
            {
                // return the bullet to who called for the bullet
                return allBulletsCreated[i];
            }
        }

        GameObject go = Instantiate(bullet);
        go.SetActive(false);
        allBulletsCreated.Add(go);
        return go;
    }
}
