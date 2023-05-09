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
        }
    }
}
