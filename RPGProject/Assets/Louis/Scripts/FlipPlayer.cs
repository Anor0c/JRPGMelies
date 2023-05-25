using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayer : MonoBehaviour
{
    [SerializeField] ColliderFlipBoss colliderFlipBoss; 
    SpriteRenderer sprite;
    Vector3 playerComparaison;
    Transform thisTransform; 
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        thisTransform = GetComponentInParent<Transform>(); 
    }

    public void FlipPlayerSprite(Vector2 _playerDir)
    {
        if (_playerDir.x < 0)
        {
            sprite.flipX = true; 
        }
        else
        {
            sprite.flipX = false; 
        }
    }
    public void FlipBossSprite(Vector3 _playerPos)
    {
        playerComparaison = thisTransform.position - _playerPos;
        if (playerComparaison.x < 0)
        {
            sprite.flipX = true;
            colliderFlipBoss.Flip(); 
        }
        else
        {
            sprite.flipX = false;
            colliderFlipBoss.Flip(); 
        }
    }
}
