using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FreeLook : StateMachineBehaviour
{
    [SerializeField]
    GameObject ActionMenu;
    [SerializeField]
    UIObject UIObject;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ActionMenu = animator.GetComponent<UIObject>().UIActionMenu;
        UIObject = animator.GetComponent<UIObject>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (UIObject.isInspected == true)
        {
            animator.SetBool("isInspected", true);
        }

        UIObject.UIPlayerController.UIInteractable.transform.Rotate(UIObject.UIPlayerController.FreeLookRotate, Space.World);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ActionMenu.SetActive(true);
        UIObject.Interactable.transform.rotation = Quaternion.Lerp(UIObject.Interactable.transform.rotation, UIObject.VerticalBottleTransform.transform.rotation, 3*Time.deltaTime);
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
