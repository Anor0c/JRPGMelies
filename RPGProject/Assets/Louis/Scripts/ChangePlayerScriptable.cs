using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerScriptable : MonoBehaviour
{
    [SerializeField] [Range(0, 2)] int statIndex = 0;
    [SerializeField] public PlayerScriptable[] statArray;
    [SerializeField] PlayerMove playerMove;
    [SerializeField] HealthBehaviour playerHealth;
    [SerializeField] ChangeHealthUI changeHealthUI;
    [SerializeField] new SpriteRenderer renderer; 

    private void Awake()
    {
        renderer = GetComponentInChildren<SpriteRenderer>(); 
        playerMove = GetComponent<PlayerMove>();
        playerHealth = GetComponent<HealthBehaviour>();
    }
    private void Start()
    {
        ChangeStat(0);  
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
        changeHealthUI.changeUIhealth();
    }  

}
