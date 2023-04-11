using UnityEngine.InputSystem; 
using UnityEngine;

 
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float grav=9.87f;
    Vector2 inputDir;
 

    CharacterController controller; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
            inputDir = Vector2.zero;
        inputDir = ctx.ReadValue<Vector2>(); 
    }

    private Vector3 GravityVector()
    {
        if (controller.isGrounded)
        {
            return new Vector3(0, 0, 0);
        }
        return new Vector3(0, grav, 0);
    }

    void FixedUpdate()
    {
        var _playerDir = new Vector3(inputDir.x, 0, inputDir.y); 
        controller.Move(_playerDir*speed);
    }
}
