using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosSwitchPhase : MonoBehaviour
{
    HealthBehaviour health; 

    void Start()
    {
        health = GetComponent<HealthBehaviour>(); 
    }

    public void BossChangePhase()
    {
        Debug.Log("bossChange"); 
    }
}
