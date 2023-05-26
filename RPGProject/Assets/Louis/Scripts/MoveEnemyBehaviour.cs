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
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        flip.FlipBossSprite(player.transform.position);
        AIAgent.SetDestination(player.transform.position);
        currentMoveTime -= Time.deltaTime;
        if (currentMoveTime >= 0f)
            return;
        else
        {
            var _distanceVector = AIAgent.transform.position - player.transform.position;
            distanceToPlayer = _distanceVector.magnitude;
            if (distanceToPlayer < 5f)
            {
                animator.SetBool("isAttack", true);
            }
            else
            {
                int random = Random.Range(0, 1);
                if (random == 0)
                    animator.SetBool("isAttackRange", true);
                else
                    animator.SetBool("isAttack", true); 
            }
            animator.SetBool("isMove", false);
            AIAgent.SetDestination(AIAgent.transform.position);
        }

    }
}
