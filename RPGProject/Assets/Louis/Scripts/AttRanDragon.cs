using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttRanDragon : StateMachineBehaviour
{
    RotateCollider rotate;
    InstanciateProjectil spawner;
    FlipPlayer flip; 
    Transform playerTransform;
    Vector3 aimVector; 
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rotate = animator.GetComponentInChildren<RotateCollider>();
        spawner = animator.GetComponentInChildren<InstanciateProjectil>();
        flip = animator.GetComponentInChildren<FlipPlayer>(); 
        playerTransform = FindObjectOfType<PlayerMove>().transform; 
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        aimVector = playerTransform.position - animator.transform.position;  
        spawner.createProjectil();
        rotate.RotateOnInput(new Vector2(aimVector.x, aimVector.z).normalized);
        flip.FlipBossSprite(playerTransform.position);
    }
}
