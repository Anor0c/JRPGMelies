using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float attackDelay = 1f;
    [SerializeField] bool canAttack = true;
    [SerializeField] AttackDamage attackHitbox; 

    private void Start()
    {
        attackHitbox = GetComponentInChildren<AttackDamage>(true); 
    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if (!ctx.started)
            return;
        if (!canAttack)
        {
            Debug.Log("can't cancel attack");
        } 
        StartCoroutine(DelayRoutine());
        attackHitbox.gameObject.SetActive(true);
        Debug.Log("Attack!!");
    }
    IEnumerator DelayRoutine()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
        yield return null;
    }
}
