using UnityEngine;

public class EnnemiStructure : MonoBehaviour
{
    [Header("Ennemi name")]
    [SerializeField] string Name;

    [Header("MaxHealth")]
    [SerializeField] float maxHealth;

    [Header("Shield")]
    [SerializeField] float shield;

    [Header("Basic sprite")]
    [SerializeField] SpriteRenderer baseSprite;

    [Header("Death sprite")]
    [SerializeField] SpriteRenderer deathSprite;
}
