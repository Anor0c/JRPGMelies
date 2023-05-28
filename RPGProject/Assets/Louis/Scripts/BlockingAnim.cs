using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class BlockingAnim : MonoBehaviour
{
    Collider colider;
    Animator animator; 

    void Start()
    {
        colider = GetComponent<Collider>();
        animator = GetComponent<Animator>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        animator.SetBool("isBlock", true); 
    }
}
