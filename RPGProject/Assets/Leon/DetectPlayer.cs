using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] private GameObject attackBox;
    [SerializeField] string tagToAttack;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);

        if (other.gameObject.tag == "Ennemis")
            return;

        if (other.gameObject.tag == tagToAttack)
        {
            Debug.Log("j'ai trigger ce que je voulais dans mon collider");
            attackBox.SetActive(true);
        }
    }
}
