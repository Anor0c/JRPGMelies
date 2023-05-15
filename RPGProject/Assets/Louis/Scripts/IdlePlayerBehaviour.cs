using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdlePlayerBehaviour : StateMachineBehaviour
{
    [SerializeField]float idleTimer=5f, currentTime;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentTime = idleTimer;
        var _agent = animator.GetComponent<NavMeshAgent>();

        //_agent.SetDestination(_agent.transform.position);
        if (animator.GetBool("isStun"))
        {
            OnForceIdle(animator.GetFloat("stunDuration")); 
        }
    }
    public void OnForceIdle(float _stunTime)
    {
        currentTime = _stunTime;
        Debug.Log("forced"); 
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
