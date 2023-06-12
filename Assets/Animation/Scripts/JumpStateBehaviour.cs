using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStateBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("JumpUp") == true)
        {
            animator.SetBool("JumpUp", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("JumpUp", false);
    }
}
