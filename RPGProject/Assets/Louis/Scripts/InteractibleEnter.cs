using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractibleEnter : MonoBehaviour
{
    public UnityEvent OnInteract;
    PlayerInteract player;
    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject.GetComponent<PlayerInteract>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (player.isPressed)
        {
            OnInteract.Invoke();
        }
    }
}
