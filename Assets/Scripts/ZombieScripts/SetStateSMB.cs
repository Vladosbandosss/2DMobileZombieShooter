using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SetStateSMB : StateMachineBehaviour
{
    public int numberAnimRamdom;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        int randState = Random.Range(1, numberAnimRamdom+1);
        animator.SetInteger(TagManager.RANDOMPARAMETR, randState);
    }
}
