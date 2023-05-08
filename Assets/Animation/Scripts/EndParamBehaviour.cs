using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndParamBehaviour : StateMachineBehaviour
{
    public string parameter;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(parameter, false);
    }
}
