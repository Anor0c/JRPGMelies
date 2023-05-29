using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractibleEnter : MonoBehaviour
{
    public UnityEvent OnInteract;
    [SerializeField] int nextSceneIndex; 
    PlayerInteract player;
    SceneScript loader;
    private void Start()
    {
        loader = FindObjectOfType<SceneScript>(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject.GetComponent<PlayerInteract>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (player.isPressed)
        {
            OnInteract.Invoke();
            loader.LoadLevel(nextSceneIndex); 
        }
    }
}
