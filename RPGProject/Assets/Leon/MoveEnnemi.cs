using UnityEngine;

public class MoveEnnemi : MonoBehaviour
{
    public bool canMove;

    [SerializeField] private PlayerMove player;
    [SerializeField] private float speedMove;
    private float distance;

    private void Start()
    {
       player = FindObjectOfType<PlayerMove>();
    }

    private void Update()
    {
        if (canMove != true)
            return;

        distance = Vector3.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance >= 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedMove);
            transform.LookAt(player.transform);
            
            Vector3 targetDirection = player.transform.position - transform.position; // Determine which direction to rotate towards
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 0.0f, 0.0f); // Rotate the forward vector towards the target direction
            transform.rotation = Quaternion.LookRotation(newDirection); // Calculate a rotation a step closer to the target and applies rotation to this object
        }
    }
}
