using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void ToCombat()
    {
        SceneManager.LoadScene("CombatSceneLouis");
    }
}