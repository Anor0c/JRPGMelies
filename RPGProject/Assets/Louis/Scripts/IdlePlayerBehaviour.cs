using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdlePlayerBehaviour : StateMachineBehaviour
{
    [SerializeField]float idleTimer=5f, currentTime;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentTime = idleTimer+ Random.Range(-3,2);
        var _agent = animator.GetComponent<NavMeshAgent>();

    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0f && !animator.GetBool("isAttack")) 
        {
            animator.SetBool("isMove", true);
        }
    }
}
