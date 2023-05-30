using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttRanDragon : StateMachineBehaviour
{
    [SerializeField] float attackTime=3f, currentTime; 
    RotateCollider rotate;
    InstanciateProjectil[] spawner;
    FlipPlayer flip; 
    Transform playerTransform;
    Vector3 aimVector; 
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentTime = attackTime; 
        rotate = animator.GetComponentInChildren<RotateCollider>();
        spawner = animator.GetComponentsInChildren<InstanciateProjectil>();
        flip = animator.GetComponentInChildren<FlipPlayer>(); 
        playerTransform = FindObjectOfType<PlayerMove>().transform; 
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (currentTime <= 0f)
        {
            animator.SetBool("isAttackRange", false);
        }
        else
        {
            currentTime -= Time.deltaTime;
            aimVector = playerTransform.position - animator.transform.position;
            foreach (InstanciateProjectil _spawner in spawner)
                _spawner.createProjectil();
            rotate?.RotateOnInput(new Vector2(aimVector.x, aimVector.z).normalized);
            flip.FlipBossSprite(playerTransform.position);
        }
    }
}
