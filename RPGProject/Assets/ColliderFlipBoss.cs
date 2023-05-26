using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFlipBoss : MonoBehaviour
{
    [SerializeField]SpriteRenderer sprite;
    [SerializeField] float ecart = 6; 
    public void Flip()
    {
        if (sprite.flipX == true)
        {
            transform.localPosition = new Vector3(ecart,0,0);  
        }
        else
        {
            transform.localPosition = new Vector3(-ecart,0,0);
        }
    }
}
