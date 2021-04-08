using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public int waveNumber;
    public int hardCurrency;

    //---

    public static int SpaceCoinCount = 00;
    public int InternalCoin;

    public TextMeshProUGUI hardCurrencyInGame;
    public TextMeshProUGUI ScoreDisplay;
    public TextMeshProUGUI hardCurrencyFinal;

    public GameObject SpendButtonE1;
    public GameObject SpendButtonE2;
    public GameObject SpendButtonD1;
    public GameObject SpendButtonD2;
    public GameObject SpendButtonD3;
    public GameObject AdButton;

    void Start()
    {
        ShowAdButton();
    }

    //---

    private void Awake()
    {
        hardCurrency = PlayerPrefs.GetInt("hard");

        if ((instance != null) & (instance != this)) Destroy(gameObject);

        instance = this;


        //DontDestroyOnLoad(gameObject);
    }
    
    //---

    void Update()
    {
        InternalCoin = SpaceCoinCount;
        hardCurrencyInGame.text = "You have " + hardCurrency + " space coins";

        ScoreDisplay.text = "Your score is: " + score;
    }

    public void Spend10()
    {
        GameManager.SpaceCoinCount -= 10;

        if (GameManager.SpaceCoinCount <= 0)
        {
            SpendButtonD1.SetActive(false);
            SpendButtonE1.SetActive(false);
            SpendButtonD2.SetActive(false);
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 10)
        {
            SpendButtonE1.SetActive(false);
            SpendButtonD2.SetActive(false);
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 20)
        {
            SpendButtonD2.SetActive(false);
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 30)
        {
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 40)
        {
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
    }
    public void Spend20()
    {
        GameManager.SpaceCoinCount -= 20;

        if (GameManager.SpaceCoinCount <= 0)
        {
            SpendButtonD1.SetActive(false);
            SpendButtonE1.SetActive(false);
            SpendButtonD2.SetActive(false);
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 10)
        {
            SpendButtonE1.SetActive(false);
            SpendButtonD2.SetActive(false);
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 20)
        {
            SpendButtonD2.SetActive(false);
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 30)
        {
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 40)
        {
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
    }
    public void Spend30()
    {
        GameManager.SpaceCoinCount -= 30;

        if (GameManager.SpaceCoinCount <= 0)
        {
            SpendButtonD1.SetActive(false);
            SpendButtonE1.SetActive(false);
            SpendButtonD2.SetActive(false);
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 10)
        {
            SpendButtonE1.SetActive(false);
            SpendButtonD2.SetActive(false);
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 20)
        {
            SpendButtonD2.SetActive(false);
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 30)
        {
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 40)
        {
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
    }
    public void Spend40()
    {
        GameManager.SpaceCoinCount -= 40;

        if (GameManager.SpaceCoinCount <= 0)
        {
            SpendButtonD1.SetActive(false);
            SpendButtonE1.SetActive(false);
            SpendButtonD2.SetActive(false);
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 10)
        {
            SpendButtonE1.SetActive(false);
            SpendButtonD2.SetActive(false);
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 20)
        {
            SpendButtonD2.SetActive(false);
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 30)
        {
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 40)
        {
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
    }
    public void Spend50()
    {
        GameManager.SpaceCoinCount -= 50;

        if (GameManager.SpaceCoinCount <= 0)
        {
            SpendButtonD1.SetActive(false);
            SpendButtonE1.SetActive(false);
            SpendButtonD2.SetActive(false);
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 10)
        {
            SpendButtonE1.SetActive(false);
            SpendButtonD2.SetActive(false);
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 20)
        {
            SpendButtonD2.SetActive(false);
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 30)
        {
            SpendButtonE2.SetActive(false);
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 40)
        {
            SpendButtonD3.SetActive(false);
            AdButton.SetActive(true);
        }
    }

    public void Buy10()
    {
        GameManager.SpaceCoinCount += 10;

        if (GameManager.SpaceCoinCount == 10)
        {
            SpendButtonD1.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 20)
        {
            SpendButtonE1.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 30)
        {
            SpendButtonD2.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 40)
        {
            SpendButtonE2.SetActive(true);
        }
        if (GameManager.SpaceCoinCount == 50)
        {
            SpendButtonD3.SetActive(true);
        }
    }

    public void ShowAdButton()
    {
        AdButton.SetActive(true);
        SpendButtonD1.SetActive(false);
        SpendButtonE1.SetActive(false);
        SpendButtonD2.SetActive(false);
        SpendButtonE2.SetActive(false);
        SpendButtonD3.SetActive(false);
    }

    //---

    public void ChangeHardCurrency(int changeValue)
    {
        hardCurrency += changeValue;
        PlayerPrefs.SetInt("hard",hardCurrency);
        hardCurrencyFinal.text = "Now you have " + hardCurrency + " space coins";
    }
    public void ChangeScore(int changeValue)
    {
        score += changeValue/10;        
    }
}