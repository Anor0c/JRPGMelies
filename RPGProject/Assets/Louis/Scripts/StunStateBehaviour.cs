using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunStateBehaviour : StateMachineBehaviour
{
    float stunDuration; 
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stunDuration = animator.GetFloat("stunDuration"); 
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("stunDuration", stunDuration);
        stunDuration -= Time.deltaTime;
        if (stunDuration <= 0)
            animator.SetBool("isStun", false);         
    }
}
