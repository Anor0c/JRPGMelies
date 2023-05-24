using UnityEngine;

public class PowerDamageProjectil : MonoBehaviour
{
    [SerializeField] private float speedForce = 0.5f;
    private Rigidbody myRigidBody;

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        myRigidBody.AddForce(transform.forward* speedForce);
    }
}
