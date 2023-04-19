using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerType", menuName = "PlayerType", order = 3)]
public class PlayerScriptable : ScriptableObject
{
    [Header("Health")]
    public float maxHealth; 
    [Header("Movement")]
    public float walkSpeed; 
    public float dashSpeed; 
    public float dashDuration; 

}
