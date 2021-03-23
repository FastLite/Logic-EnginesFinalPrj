using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable_Objects/Enemy", order = 1)]

[System.Serializable]
public class EnemySO : ScriptableObject
{
    public int maxHealth;
    public int collisionDamage;
    public int bulletDamage;
    public float speed;
    
}
