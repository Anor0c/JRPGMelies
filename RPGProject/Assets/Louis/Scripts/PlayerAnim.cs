using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerAnim : MonoBehaviour
{
    Animator animator;
    PlayerAttack playerAttack; 
    void Start()
    {
        animator = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>(); 
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
            animator.SetBool("isMove", false);
        else
            animator.SetBool("isMove", true); 
    }
    public void OnDash(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
            animator.SetBool("isDash", false);
        else
            animator.SetBool("isDash", true);
    }
    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            animator.SetBool("isAttack", false);
        else
            animator.SetBool("isAttack", false); 
        if (!playerAttack.canAttack)
            animator.SetBool("isAttack", false); 
        else
            animator.SetBool("isAttack", true); 
    }
    public void OnBlock(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
            animator.SetBool("isRaiseShield", false);
        else
            animator.SetBool("isRaiseShield", true); 
    }

}
