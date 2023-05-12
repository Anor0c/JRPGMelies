using UnityEngine;
using System.Collections;

public class AttackDammageEnnemi : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    private MoveEnnemi Movechange;

    private void Start()
    {
        //Movechange = GetComponent<MoveEnnemi>();
        Movechange = GetComponentInParent<MoveEnnemi>();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent<HealthBehaviour>(out HealthBehaviour playerHealth);

        if (!playerHealth)
            return;

        if (other != null)
        {
            Movechange.canMove = false;
            playerHealth.TakeDamage(damage);
            gameObject.SetActive(false);
            Movechange.canMove = true;
        }

        if (other == null)
            Movechange.canMove = true;
    }
}
