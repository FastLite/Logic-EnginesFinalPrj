using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Items : MonoBehaviour
{
    public enum ItemType
    {
        Satelite,
        Earthx2,
        Spaceship,
        Earthx4,
        DeathStar
    }

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Satelite:  return 10;
            case ItemType.Earthx2:   return 20;
            case ItemType.Spaceship: return 30;
            case ItemType.Earthx4:   return 40;
            case ItemType.DeathStar: return 50;
        }
    }
}
