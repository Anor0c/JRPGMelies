using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderSearch : MonoBehaviour
{
    SceneScript loader;
    [SerializeField] int nextSceneIndex; 
    void Start()
    {
        loader = FindObjectOfType<SceneScript>(); 
    }

    public void nextScene(int _nextSceneIndex)
    {
        loader.LoadLevel(_nextSceneIndex); 
    }
}
