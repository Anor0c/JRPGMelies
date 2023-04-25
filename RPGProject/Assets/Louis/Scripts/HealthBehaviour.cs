using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class HealthBehaviour : MonoBehaviour
{
    [SerializeField] float maxHealth = 10f, currentHealth;

    [SerializeField] Image healthUI;
    [SerializeField] EnemyScrpitable enemyStat;
    [SerializeField] PlayerScriptable playerStat;
    public UnityEvent OnDeath;
    private void Awake()
    {
        OnChangedScriptable();
    }
    void Start()
    {
        currentHealth = maxHealth; 
    }

    private void OnChangedScriptable()
    {
        if (enemyStat != null)
            maxHealth = enemyStat.maxHealth;

        if (playerStat != null)
            maxHealth = playerStat.maxHealth;     
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
