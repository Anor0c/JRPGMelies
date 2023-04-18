using UnityEngine.InputSystem; 
using UnityEngine;

public class SwitchInputMaps : MonoBehaviour
{
    public void SwitchToCombat()
    {
        GetComponent<PlayerInput>().SwitchCurrentActionMap("Combat");
    }
    public void SwitchToRoaming()
    {
        GetComponent<PlayerInput>().SwitchCurrentActionMap("Roaming");
    }
}
