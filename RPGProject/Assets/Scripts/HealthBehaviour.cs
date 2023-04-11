using UnityEngine;
using UnityEngine.Events;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField] float maxHealth = 10f, currentHealth;
    public UnityEvent OnDeath;
    void Start()
    {
        currentHealth = maxHealth; 
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= maxHealth)
        {
            OnDeath.Invoke();
        }
    }
}
