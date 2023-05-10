using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoadScriptable : MonoBehaviour
{
    PlayerScriptable _player; 
    [Range(0,1)]public int index;
    // Start is called before the first frame update
    void Start()
    {
        var _ass = Resources.Load("ScriptableObjects/Players/GlassCannon") as PlayerScriptable;
        Debug.Log(_ass.walkSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        if (index == 0)
        {
             _player = Resources.Load("ScriptableObjects/Players/GlassCannon") as PlayerScriptable;
        }
        else
        {
            _player= Resources.Load("ScriptableObjects/Players/Tank") as PlayerScriptable;
        }
        Debug.Log("player is walkspeed"+_player.walkSpeed);
    }
}
