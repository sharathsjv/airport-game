using UnityEngine;
using UnityEngine.AI;

public class NpcStates : StateMachineBehaviour
{
    [SerializeField]
    float waitTime, currentTime;

    [SerializeField]
    float waitMinRange, waitMaxRange, randomMinRange, randomMaxRange;
    


    public enum GenericSNPCtates
    {
        RandomWalk,
        Start_queuing,
        QueueStationary,
        RandomStationary,
        RandomWalk2,


    }

    int QueueID;

    public GenericSNPCtates states;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (states == GenericSNPCtates.RandomWalk)
        {
            ResetTimer(5f,10f);
            animator.GetComponent<GenericNPCBrain>().navMeshAgent.SetDestination(animator.GetComponent<GenericNPCBrain>().testTargetTransform.position);
        }

        if (states == GenericSNPCtates.RandomWalk2)
        {
            ResetTimer(5f,10f);
            animator.GetComponent<GenericNPCBrain>().navMeshAgent.SetDestination(animator.GetComponent<GenericNPCBrain>().testTargetTransform2.position);
        }

        if (states == GenericSNPCtates.Start_queuing)
        {
            animator.GetComponent<GenericNPCBrain>().navMeshAgent.areaMask |= 1 << NavMesh.GetAreaFromName("Line");
            animator.GetComponent<GenericNPCBrain>().navMeshAgent.SetDestination(animator.GetComponent<GenericNPCBrain>().TargetTransform.position);
        }

        if (states == GenericSNPCtates.QueueStationary)
        {
            
        }

        if (states == GenericSNPCtates.RandomStationary)
        {
            animator.GetComponent<GenericNPCBrain>().navMeshAgent.SetDestination(animator.transform.position);
            ResetTimer(0f, 4f);

        }
    }

    void ResetTimer(float minValue, float maxValue)
    {
        currentTime = 0;
        waitTime = Random.Range(minValue, maxValue);
    }
    

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (states == GenericSNPCtates.RandomWalk2 || states == GenericSNPCtates.RandomWalk || states == GenericSNPCtates.RandomStationary)
        {
            currentTime += Time.deltaTime;
            if (currentTime > waitTime)
            {
                animator.SetTrigger("RStationary");
            }

        }


    }

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
