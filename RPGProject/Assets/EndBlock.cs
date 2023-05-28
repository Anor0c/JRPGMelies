using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBlock : StateMachineBehaviour
{
    

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isBlock", false); 
    }

    
}
