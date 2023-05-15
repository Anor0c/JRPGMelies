using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AttackDamage : MonoBehaviour
{
    Collider hitbox;
    [SerializeField]float duration=1f;
    [SerializeField]float damage=1f;
    [SerializeField]string ignoreTag; 
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
    //OnTriggerEnter ne marche qu'avec les GameObject ave un rigidBody ou un Chracter Controller pour une raison mystique
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.tag == ignoreTag)
            return;

        other.gameObject.TryGetComponent(out HealthBehaviour enemyHealth);
        if (!enemyHealth)
            return;
        enemyHealth.TakeDamage(damage);
        gameObject.SetActive(false); 
    }
}
