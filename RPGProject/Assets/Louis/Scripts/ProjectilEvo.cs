using System.Collections;
using UnityEngine;

public class ProjectilEvo : MonoBehaviour
{
    [SerializeField] float fastSpeed = 5f, slowSpeed = 0.5f, slowDuration=1f;
    Rigidbody rb;
    ProjAnimFlip animFlip; 
    Transform player; 
    void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;  
        rb = GetComponent<Rigidbody>();
        animFlip = GetComponent<ProjAnimFlip>(); 
        StartCoroutine(SlowRoutine()); 
    }
    IEnumerator SlowRoutine()
    {
        yield return null;
        rb.velocity=(transform.forward * slowSpeed);
        yield return new WaitForSeconds(slowDuration);
        RecomputePlayerPos(); 
        rb.velocity = transform.forward * fastSpeed;
        yield return null; 
    }
    void RecomputePlayerPos()
    {
        if (!player)
            return;
        transform.LookAt(player, Vector3.up);
        animFlip.CheckFlip();
    }
}
