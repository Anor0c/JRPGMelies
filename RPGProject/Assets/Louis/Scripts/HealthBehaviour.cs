using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class HealthBehaviour : MonoBehaviour
{
    [Header ("Scriptable")]
    [SerializeField] EnemyScrpitable enemyStat;
    [SerializeField] PlayerScriptable playerStat;

    [SerializeField] float maxHealth = 10f, currentHealth;
    [SerializeField] Image healthUI;

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
        if (healthUI != null)
            healthUI.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            OnDeath.Invoke();
        }
    }
}
