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
        MoveAhead,
        FinishQueue,
        RandomStationary,
        RandomWalk2,
        JustGoMan,


    }

    int QueueID;

    public GenericSNPCtates states;
[SerializeField]
    GenericNPCBrain thebrain;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (thebrain == null)
        {
            thebrain = animator.GetComponent<GenericNPCBrain>();
        }

        if (states == GenericSNPCtates.RandomWalk)
            {
                ResetTimer(5f, 10f);
                animator.GetComponent<GenericNPCBrain>().navMeshAgent.SetDestination(animator.GetComponent<GenericNPCBrain>().testTargetTransform.position);
            }

        if (states == GenericSNPCtates.RandomWalk2)
        {
            ResetTimer(5f, 10f);
            animator.GetComponent<GenericNPCBrain>().navMeshAgent.SetDestination(animator.GetComponent<GenericNPCBrain>().testTargetTransform2.position);
        }

        if (states == GenericSNPCtates.Start_queuing)
        {
            thebrain.navMeshAgent.areaMask |= 1 << NavMesh.GetAreaFromName("Line");
            thebrain.navMeshAgent.SetDestination(animator.GetComponent<GenericNPCBrain>().TargetTransform.position);
        }

        if (states == GenericSNPCtates.QueueStationary)
        {
            
            if (thebrain.CurrentNumberInQueue.queueNumber == 1)
            {
                ResetTimer(20f, 30f);

            }
            if (thebrain.CurrentNumberInQueue.queueNumber >1)
            {
                if (thebrain.CurrentNumberInQueue.ParentQueueScript.queueItems[thebrain.CurrentNumberInQueue.queueNumber-2] == null)
                {
                    animator.SetTrigger("MoveAhead");

                }
            }
        }

        if (states == GenericSNPCtates.RandomStationary)
        {
            animator.GetComponent<GenericNPCBrain>().navMeshAgent.SetDestination(animator.transform.position);
            ResetTimer(0f, 4f);

        }

        if (states == GenericSNPCtates.FinishQueue)
        {
            animator.GetComponent<GenericNPCBrain>().navMeshAgent.areaMask |= 1 << NavMesh.GetAreaFromName("Post-Line");
            animator.GetComponent<GenericNPCBrain>().navMeshAgent.ResetPath();
            animator.GetComponent<GenericNPCBrain>().navMeshAgent.SetDestination(animator.GetComponent<GenericNPCBrain>().UpstairsTransform.position);
            animator.GetComponent<GenericNPCBrain>().isQueuing = false;
            animator.GetComponent<GenericNPCBrain>().isStationary = false;
            thebrain.CurrentNumberInQueue.ChosenOne = null;
        }

        if (states == GenericSNPCtates.JustGoMan)
        {
            animator.GetComponent<GenericNPCBrain>().navMeshAgent.SetDestination(animator.GetComponent<GenericNPCBrain>().UpstairsTransform.position);
        }

        if (states == GenericSNPCtates.MoveAhead)
        {
            thebrain._Collider.enabled = false;
            thebrain.CurrentNumberInQueue.ReArrangeQueue();
            thebrain.CurrentNumberInQueue = thebrain.CurrentNumberInQueue.ParentQueueScript.queueItems[thebrain.CurrentNumberInQueue.queueNumber - 2];
            thebrain.navMeshAgent.SetDestination(thebrain.CurrentNumberInQueue.transform.position);
            ResetTimer(1, 1);
            thebrain.isStationary = false;


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

        if (states == GenericSNPCtates.QueueStationary)
        {

            if (thebrain.CurrentNumberInQueue.queueNumber == 1)
            {
                currentTime += Time.deltaTime;
                if (currentTime > waitTime)
                {
                    animator.SetTrigger("FinishQueue");

                }

            }

            if (thebrain.CurrentNumberInQueue.queueNumber > 1)
            {
                Debug.Log(thebrain.CurrentNumberInQueue.ParentQueueScript.queueItems[thebrain.CurrentNumberInQueue.queueNumber - 2]);
                if (thebrain.CurrentNumberInQueue.ParentQueueScript.queueItems[thebrain.CurrentNumberInQueue.queueNumber - 2].ChosenOne == null)
                {
                    animator.SetTrigger("MoveAhead");

                }
            }
        }
        
        if (states == GenericSNPCtates.MoveAhead)
            {
                currentTime += Time.deltaTime;
                
                
                if (currentTime > waitTime)
                {
                    thebrain._Collider.enabled = true;
                        
                }
            }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (states == GenericSNPCtates.QueueStationary)
        {
            thebrain.isStationary = false;

        }

        if (states == GenericSNPCtates.MoveAhead)
        {
            thebrain.CurrentNumberInQueue.ParentQueueScript.queueItems[thebrain.CurrentNumberInQueue.queueNumber]._ChosenOne = null;
        }

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
