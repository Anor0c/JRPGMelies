using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerScriptable : MonoBehaviour
{
    [SerializeField] int defaultIdex = 0; 
    [SerializeField] [Range(0, 2)] int statIndex = 0;
    [SerializeField] public PlayerScriptable[] statArray;
    PlayerMove playerMove;
    HealthBehaviour playerHealth;
    [SerializeField] ChangeHealthUI changeHealthUI;
     new SpriteRenderer renderer;
    [SerializeField] Animator animator; 

    private void Awake()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponentInChildren<SpriteRenderer>(); 
        playerMove = GetComponent<PlayerMove>();
        playerHealth = GetComponent<HealthBehaviour>();
    }
    private void Start()
    {
        statIndex = defaultIdex;
        ChangeStat(statIndex);  
    }
    public void OnEvolution()
    {
        statIndex++;
        if (statIndex >= 2)
            statIndex = 2; 
        ChangeStat(statIndex);
    }
    void ChangeStat(int _index)
    {
        renderer.sprite = statArray[_index].sprite; 
        playerHealth.OnChangedPlayerScriptable(statArray[_index]);
        playerMove.OnChangeScriptable(statArray[_index]);
        animator.runtimeAnimatorController = statArray[_index].controller; 
        //changeHealthUI.changeUIhealth();
    }  

}
