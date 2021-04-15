using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;

    public int score;
    public int waveNumber;
    public int hardCurrency;

    public TextMeshProUGUI hardCurrencyInGame;
    public TextMeshProUGUI ScoreDisplay;
    public TextMeshProUGUI hardCurrencyFinal;
    
    public GameObject AdButton;

    void Start()
    {
        ShowAdButton();
    }
    private void Awake()
    {
        //Set the number of hard currency to the saved value in player prefs
        hardCurrency = PlayerPrefs.GetInt("hard");
        
        //Make instance of the game manager and check if it's no already on the scene
        if ((instance != null) & (instance != this)) Destroy(gameObject);
        instance = this; 
    }
    void Update()
    {
        hardCurrencyInGame.text = "WALLET: " + hardCurrency + " space coins";

        ScoreDisplay.text = "Your score is: " + score;
    }

    public void ShowAdButton()
    {
        AdButton.SetActive(true);
    }
    
    //Change the number of hard currency and update it in player prefs
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