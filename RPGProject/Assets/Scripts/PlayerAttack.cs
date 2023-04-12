using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Collider attackHitbox;


    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if (!ctx.started)
            return;
           
        attackHitbox.gameObject.SetActive(true);
        Debug.Log("Attack!!");
    }
}
