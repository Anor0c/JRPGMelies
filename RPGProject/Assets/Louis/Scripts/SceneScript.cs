using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void ToCombat()
    {
        SceneManager.LoadScene(2);
    }
    public void ToRoaming()
    {
        SceneManager.LoadScene(1); 
    }
}