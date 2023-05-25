using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "EnemyType", order = 2)]
public class EnemyScrpitable : ScriptableObject
{
    [Header("Ennemi name")]
    public string ennemyName;

    [Header("Health")]
    public float maxHealth;

    [Header("Speed")]
    public float speed;

    [Header("Animator")]
    public RuntimeAnimatorController controller;  

    /*[Header("Basic sprite")]
    public SpriteRenderer baseSprite;

    [Header("Death sprite")]
    public SpriteRenderer deathSprite;*/
}
