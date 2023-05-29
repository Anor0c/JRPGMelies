using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjAnimFlip : MonoBehaviour
{
    Rigidbody rb; 
    new SpriteRenderer renderer; 

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        CheckFlip(); 
    }

    public void CheckFlip()
    {
        if (rb.velocity.x < 0)
        {
            renderer.flipX = true; 
        }
        else
        {
            renderer.flipX = false; 
        }
    }
}
