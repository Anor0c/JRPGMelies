using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICallMoveRoutine : MonoBehaviour
{
    public void Call()
    {
        StartCoroutine("MoveRoutine");
    }
}
