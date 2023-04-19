using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class HealthBehaviour : MonoBehaviour
{
    [SerializeField] float maxHealth = 10f, currentHealth;

    [SerializeField] Image healthUI;
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
        healthUI.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            OnDeath.Invoke();
        }
    }
}
