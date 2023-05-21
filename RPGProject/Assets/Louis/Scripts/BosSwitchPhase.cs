using UnityEngine;
public class BosSwitchPhase : MonoBehaviour
{
    public EnemyScrpitable bossStat; 

    public void BossChangePhase()
    {
        var animator = GetComponent<Animator>(); 
        var health = GetComponent<HealthBehaviour>();
        animator.runtimeAnimatorController = bossStat.controller; 
        health.OnChangedEnemyScriptable(bossStat); 

    }
}
