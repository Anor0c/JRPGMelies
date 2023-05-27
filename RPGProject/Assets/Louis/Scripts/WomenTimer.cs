using UnityEngine;
using UnityEngine.Events; 

public class WomenTimer : MonoBehaviour
{
    [SerializeField] float timer, currentTime;
    public UnityEvent OnTimerEnd; 
    void Start()
    {
        currentTime = timer;  
    }
    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0f)
        {
            OnTimerEnd.Invoke(); 
        }
    }


}
