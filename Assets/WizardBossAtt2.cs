using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBossAtt2 : StateMachineBehaviour
{
    private Vector3 playerlocation;
    private WizardBoss wb;
    private GameObject t;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        wb = animator.gameObject.GetComponent<WizardBoss>();
        animator.SetBool("att2", false);
        playerlocation = wb.player.transform.position;
        t = Instantiate(wb.test, playerlocation, wb.transform.localRotation);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(t);
        GameObject fb = wb.fireball;
        fb.transform.localScale = new Vector3(3.5f, 3.5f, 0f);
        GameObject s = Instantiate(fb, playerlocation, wb.transform.localRotation);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
