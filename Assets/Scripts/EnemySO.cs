using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable_Objects/Enemy", order = 1)]

[Serializable]
public class EnemySO : ScriptableObject
{
    public int maxHealth;
    public int collisionDamage;
    public int bulletDamage;
    public float speed;
    public float stopDistance;
    public int score;
}