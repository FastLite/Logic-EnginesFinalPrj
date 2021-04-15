using UnityEngine;
using UnityEngine.UI;

public class PlanetHealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHelath(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    
}
