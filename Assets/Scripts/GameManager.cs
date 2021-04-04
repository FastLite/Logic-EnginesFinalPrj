using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public int waveNumber;
    public int hardCurrency;


    private void Awake()
    {
        hardCurrency = PlayerPrefs.GetInt("hard");

        if ((instance != null) & (instance != this)) Destroy(gameObject);

        instance = this;


        DontDestroyOnLoad(gameObject);
    }

    


    private void Update()
    {
    }


    public void ChangeHardCurrency(int changeValue)
    {
        hardCurrency += changeValue;
        PlayerPrefs.SetInt("hard",hardCurrency);
    }
    public void ChangeScore(int changeValue)
    {
        score += changeValue;
        
    }

    public void Reset()
    {
        
    }
}