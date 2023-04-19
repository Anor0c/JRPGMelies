using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "EnemyType", order = 2)]
public class EnemyScrpitable : ScriptableObject
{
    public string ennemyName;
    [Header("Health")]
    public float maxHealth;
    [Header("Speed")]
    public float speed;
}
