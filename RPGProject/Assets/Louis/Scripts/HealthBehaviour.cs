using UnityEngine;
using UnityEngine.Events;


public class HealthBehaviour : MonoBehaviour
{
    [SerializeField] float maxHealth = 10f, currentHealth;
    [SerializeField] EnemyScrpitable enemyStat;
    public UnityEvent OnDeath;
    private void Awake()
    {
        if (enemyStat == null)
            return;
        maxHealth = enemyStat.maxHealth;
    }
    void Start()
    {
        currentHealth = maxHealth; 
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            OnDeath.Invoke();
        }
    }
}
