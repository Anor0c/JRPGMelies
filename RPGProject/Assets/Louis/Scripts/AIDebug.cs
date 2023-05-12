using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIDebug : MonoBehaviour
{
    NavMeshAgent AI;
    private void Start()
    {
        AI = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        Debug.Log(AI.speed);
    }
}
