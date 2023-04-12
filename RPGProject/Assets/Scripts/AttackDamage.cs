using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AttackDamage : MonoBehaviour
{
    Collider hitbox;
    [SerializeField]float duration=1f;
    [SerializeField]float damage=1f;
    private void Start()
    {
        hitbox = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        StartCoroutine(AttackDuration());
    }
    private IEnumerator AttackDuration()
    {
        yield return new WaitForSeconds(duration);
        hitbox.gameObject.SetActive(false);
        Debug.Log("attack end!!");
        yield return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent<HealthBehaviour>(out HealthBehaviour enemyHealth);
        enemyHealth.TakeDamage(damage);
    }
}
