using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class HealthBehaviour : MonoBehaviour
{
    [Header ("Scriptable")]
    [SerializeField] EnemyScrpitable enemyStat;
    [SerializeField] public PlayerScriptable playerStat;

    [SerializeField] float maxHealth = 10f, currentHealth;
    float previousMaxHealth; 
    [SerializeField] Image healthUI;

    public UnityEvent OnDeath;
    private void Awake()
    {
        if (playerStat != null)
        {
            OnChangedPlayerScriptable(playerStat);
        }
        //il faudrat changer la logique logique pour les ennemis 
        else if (enemyStat != null)
        {
            OnChangedEnemyScriptable(enemyStat); 
        }
        else
        {
            Debug.Log("No stat on " + this.gameObject); 
        }
    }
    void Start()
    {
        currentHealth = maxHealth; 
    }

    public void OnChangedPlayerScriptable(PlayerScriptable _playerStat)
    {       
        if (_playerStat != null)
        {
            previousMaxHealth = maxHealth;
            playerStat = _playerStat; 
            maxHealth = playerStat.maxHealth;
            currentHealth = (currentHealth / previousMaxHealth) * maxHealth;
            Debug.Log("Playerstat setup" + _playerStat +"currentHealth is "+ currentHealth);
        }
        Debug.Log("PlayerStat is null"); 
    }
    public void OnChangedEnemyScriptable(EnemyScrpitable _enemyStat)
    {
        if (_enemyStat != null) 
        {
            previousMaxHealth = maxHealth; 
            enemyStat = _enemyStat;
            maxHealth = enemyStat.maxHealth;
            currentHealth = (currentHealth / previousMaxHealth) * maxHealth;
            Debug.Log("enemystat setup" + enemyStat); 
        }
        Debug.Log("EnemyStat is null");
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
