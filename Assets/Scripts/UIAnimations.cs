using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIAnimations : StateMachineBehaviour
{

     public UnityEvent AnimationsToPlay;

    UIObject UIObject;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        UIObject = animator.GetComponent<UIObject>();


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AnimationsToPlay.Invoke();
        
    }

    public void RotateLookDownAniation() //From LookDownAnimation
    {
        UIObject.Interactable.transform.rotation = Quaternion.Lerp(UIObject.Interactable.transform.rotation, UIObject.LookDownTransform.transform.rotation, 4 * Time.deltaTime);
    }

    public void RemoveCapAnimation(float time = 4)
    {
        
        UIObject.Interactable2.transform.position = Vector3.Lerp(UIObject.Interactable2.transform.position, UIObject.Interactable2.transform.position + new Vector3(-0.2f, 0, 0), time * Time.deltaTime);

        
    }


    public void Add1()
    {
        Debug.Log("this is first function");
    }

    public void LerpVerticalAnimation() //From FlipAnimation
    {
        
        UIObject.Interactable.transform.rotation = Quaternion.Lerp(UIObject.Interactable.transform.rotation, UIObject.VerticalBottleTransform.transform.rotation, 4 * Time.deltaTime);
    }
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
