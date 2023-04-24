using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem; 
 
public class PlayerMove : MonoBehaviour
{
    [Header("Walk")]
    [SerializeField] float currentSpeed = 1f;
    [SerializeField] float walkSpeed = 1f;
    [SerializeField] float speedMultiplier=1f;
    [Header("Dash")]
    [SerializeField] float dashTime=1f;
    [SerializeField] float dashSpeed=10f;
    [SerializeField] bool isDash = false;
    Vector2 inputDir;
    Vector3 dashVector;

    public PlayerScriptable playerStat;
    CharacterController controller; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
            inputDir = Vector2.zero;
        inputDir = ctx.ReadValue<Vector2>(); 
    }

    public void OnDash(InputAction.CallbackContext obj)
    {
        if (isDash)
            Debug.Log("Can't cancel ur dash");

        if (obj.started)
        {
            StartCoroutine(DashRoutine());
            dashVector = new Vector3(inputDir.x, 0, inputDir.y);
        }       
    }
    private IEnumerator DashRoutine()
    {
        isDash = true;
        currentSpeed = dashSpeed;
        yield return new WaitForSeconds(dashTime);
        isDash = false;
        currentSpeed = walkSpeed;
        yield return null;

    }
    /*private Vector3 GravityVector()
    {
        if (controller.isGrounded)
        {
            return new Vector3(0, 0, 0);
        }
        return new Vector3(0, grav, 0);
    }*/
    private Vector3 PlayerDirection()
    {
        if (isDash)
        {
            return dashVector;
        }
        var _walkVector = new Vector3(inputDir.x, 0, inputDir.y) * currentSpeed * speedMultiplier;
        return _walkVector;
    }

    void FixedUpdate()
    {
        var _playerDir = PlayerDirection(); 
        controller.Move(_playerDir);
    }
}
