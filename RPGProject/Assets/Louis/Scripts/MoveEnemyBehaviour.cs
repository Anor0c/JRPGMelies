using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemyBehaviour : StateMachineBehaviour
{
    FlipPlayer flip; 
    PlayerMove player;
    NavMeshAgent AIAgent;
    float distanceToPlayer;
    [SerializeField]float moveTimer = 1f, currentMoveTime; 
   
    override public void OnStateEnter(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        flip = _animator.GetComponentInChildren<FlipPlayer>();  
        player = FindObjectOfType<PlayerMove>();
        AIAgent = _animator.GetComponent<NavMeshAgent>();
        _animator.SetBool("isMove", true);
        currentMoveTime = moveTimer+ Random.Range(-3,2); 
    }

 
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        flip.FlipBossSprite(player.transform.position); 
        AIAgent.SetDestination(player.transform.position);
        currentMoveTime -= Time.deltaTime;
        if (currentMoveTime <= 0f)
        {
            animator.SetBool("isMove", false);
            AIAgent.SetDestination(AIAgent.transform.position);
        }
        else
        {
            animator.SetBool("isMove", true); 
        }
    }

     //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var _distanceVector = AIAgent.transform.position - player.transform.position;
        distanceToPlayer = _distanceVector.magnitude;
        Debug.Log(distanceToPlayer); 
        if (distanceToPlayer <= 1f)
        {
            animator.SetBool("isAttack", true);
        }
        else
        {
            animator.SetBool("isAttackRange", true); 
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

}
