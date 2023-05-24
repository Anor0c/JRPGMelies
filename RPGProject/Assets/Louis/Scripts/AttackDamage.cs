using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AttackDamage : MonoBehaviour
{
    Collider hitbox;
    KnockBack knockBack; 
    [SerializeField]float duration=1f;
    [SerializeField]float damage=1f;
    [SerializeField] string[] ignoreTag = { "Invincible" }; 
    private void Start()
    {
        hitbox = GetComponent<Collider>();
        knockBack = GetComponent<KnockBack>(); 
    }
    private void OnEnable()
    {
        StartCoroutine(AttackDuration());
    }
    private IEnumerator AttackDuration()
    {
        yield return new WaitForSeconds(duration);
        hitbox.gameObject.SetActive(false);
        yield return null;
    }
    //OnTriggerEnter ne marche qu'avec les GameObject ave un rigidBody ou un Chracter Controller pour une raison mystique
    private void OnTriggerEnter(Collider other)
    {
        bool _canAttack = true;
        foreach (string _ignoreTag in ignoreTag)
        {
            if (other.gameObject.tag == _ignoreTag)
            {
                _canAttack = false;
                Debug.Log(other.gameObject.tag);
            }
        }

        if (_canAttack)
        {
            other.gameObject.TryGetComponent(out HealthBehaviour enemyHealth);
            if (!enemyHealth)
                return;
            if (knockBack)
            {
                knockBack.OnAttackTouched(other); 
            }
            enemyHealth.TakeDamage(damage);
            gameObject.SetActive(false);
        }

    }
}
