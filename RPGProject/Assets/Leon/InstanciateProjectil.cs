                                                            using UnityEngine;
using System.Collections; 

public class InstanciateProjectil : MonoBehaviour
{
    Transform target;
    bool isPerformed;
    [SerializeField] bool canAim = true; 
    [SerializeField] float cooldown = 1f;
    [SerializeField] private GameObject projectil;
    private void Start()
    {
        target = FindObjectOfType<PlayerMove>().transform;  
    }
    public void createProjectil()
    {
        if (isPerformed)
            return;
        else
            StartCoroutine(InstantiateRoutine());       
    }
    IEnumerator InstantiateRoutine()
    {
        isPerformed = true;
        yield return new WaitForSeconds(cooldown);
        if (canAim)
            transform.LookAt(target);
        Instantiate(projectil, transform.position, transform.rotation);
        yield return new WaitForEndOfFrame();
        isPerformed = false;
        yield return null;
    }
}
