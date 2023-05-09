using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem; 
using UnityEngine.Events; 
 
public class PlayerMove : MonoBehaviour
{
    [Header("PlayerStat")]
    public PlayerScriptable playerStat;
    [Header("Walk")]
    [SerializeField] float currentSpeed = 1f;
    [SerializeField] float walkSpeed = 1f;
    [SerializeField] float speedMultiplier=1f;
    [Header("Dash")]
    [SerializeField] float dashTime=1f;
    [SerializeField] float dashSpeed=10f;
    [SerializeField] bool isDash = false;
    [Header("Gravity")]
    [SerializeField] bool isGrounded = false;
    [SerializeField]float grav;
    [Header("StunDebug")]
    [SerializeField] bool isStun = false;
    public UnityEvent<Vector2> directionEvent;

    Vector2 inputDir;
    Vector3 dashVector;
    Vector3 kbVector;


    CharacterController controller; 

    void Start()
    {
        if (playerStat != null)
            OnChangeScriptable();

        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
    }

    void OnChangeScriptable()
    {
        walkSpeed = playerStat.walkSpeed;
        dashSpeed = playerStat.dashSpeed;
        dashTime = playerStat.dashDuration;
    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
            inputDir = Vector2.zero;
        inputDir = ctx.ReadValue<Vector2>().normalized;
        directionEvent.Invoke(ctx.ReadValue<Vector2>().normalized);
    }

    public void OnDash(InputAction.CallbackContext obj)
    {
        if (isStun)
            return;
        if (isDash)
            return;

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
    private Vector3 GravityVector()
    {
        if (isGrounded)
        {
            return new Vector3(0, 0, 0);
        }
        return new Vector3(0, grav, 0);
    }
    private Vector3 PlayerDirection()
    {
        if (isDash)
        {
            return dashVector * currentSpeed * speedMultiplier;
        }
        var _walkVector = new Vector3(inputDir.x, 0, inputDir.y) * currentSpeed * speedMultiplier;
        return _walkVector;
    }
    public void ReceiveKnockBack(Vector3 _knockbackVector, float _stunDuration)
    {
        StartCoroutine(StunRoutine());
        IEnumerator StunRoutine()
        {
            isStun = true;
            yield return new WaitForSeconds(_stunDuration);
            isStun = false;
            yield return null;
        }

        kbVector= _knockbackVector;
    }
    private void Update()
    {
        isGrounded = controller.isGrounded;
        if (!isStun)
            kbVector= Vector3.zero;
    }
    void FixedUpdate()
    {

        var _playerDir = PlayerDirection()+GravityVector()+kbVector; 
        controller.Move(_playerDir);
    }
}
