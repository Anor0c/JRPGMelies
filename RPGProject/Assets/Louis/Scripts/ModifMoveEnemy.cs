using UnityEngine;
using UnityEngine.AI; 
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class ModifMoveEnemy : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    Vector3 agentVector; 
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); 
        agentVector = agent.velocity; 
    }

    public void OnKnockbackRecieved(Vector3 _kbReceived, float _stunDuration)
    {
        if (agent == null)
            return; 
        agent.ResetPath(); 
        agent.velocity +=_kbReceived;
        animator.SetFloat("stunDuration", _stunDuration); 
        animator.SetBool("isStun", true); 
        animator.SetBool("isMove", false);
        animator.SetBool("isAttack", false); 
        animator.CrossFade("Idle", 0);
    } 
}
