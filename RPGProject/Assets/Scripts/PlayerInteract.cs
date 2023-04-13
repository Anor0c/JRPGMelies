using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public bool isPressed = false;
    public void OnInterractPressed(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            isPressed = true;
        }
        if (ctx.canceled)
        {
            isPressed = false;
        }
    }
}
