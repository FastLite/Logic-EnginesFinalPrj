using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public int waveNumber;
    

    
    void Awake()
    {
        score = 0;
        
        if (instance !=null & instance !=this)
        {
            Destroy(gameObject);
        }

        instance = this;
        
        
        DontDestroyOnLoad(gameObject);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void IncreaseScore(int changeValue)
    {
        //change score any time enemy destroyed or wave survived
        
        score += changeValue;
        
        
    }
}
