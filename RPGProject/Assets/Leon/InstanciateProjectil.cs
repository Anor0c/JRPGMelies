using UnityEngine;

public class InstanciateProjectil : MonoBehaviour
{
    [SerializeField] private GameObject projectil;

    public void createProjectil()
    {
        Instantiate(projectil, transform.position, transform.rotation, gameObject.transform);
    }
}
