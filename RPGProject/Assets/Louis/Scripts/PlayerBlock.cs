using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerBlock : MonoBehaviour
{
    public Collider blockHitbox;

    public void OnBlock(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            blockHitbox.gameObject.SetActive(true);
        }
        if (ctx.canceled)
        {
            blockHitbox.gameObject.SetActive(false);
        }
    }
}
