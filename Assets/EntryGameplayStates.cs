using UnityEngine;

public class EntryGameplayStates : StateMachineBehaviour
{

    float currentTime, waitTime;
    public enum AllEntryGameplayStates
    {
        QuestionMinigame,
        InitialDialogue,
        SecondDialogu,
        ThirdDialogu,
        QuestionMinigame2,
    }

    [SerializeField]
    EntryGameplay parententrygameplayscript;

    [SerializeField]
    AllEntryGameplayStates allEntryGameplayStates;

    [SerializeField]
    float questioningScore;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (parententrygameplayscript == null)
        {
            parententrygameplayscript = animator.GetComponent<EntryGameplay>();
        }
        if (allEntryGameplayStates == AllEntryGameplayStates.QuestionMinigame)
        {
            ResetTimer(3, 3);
            if (parententrygameplayscript.questioningGameScript != null)
            {
                parententrygameplayscript.questioningGameScript.gameObject.SetActive(true);
            }
        }

        else if (allEntryGameplayStates == AllEntryGameplayStates.QuestionMinigame2)
        {
            ResetTimer(3, 3);
            if (parententrygameplayscript.questioningGameScript != null)
            {
                parententrygameplayscript.questioningGameScript2.gameObject.SetActive(true);
            }
        }


        else if (allEntryGameplayStates == AllEntryGameplayStates.InitialDialogue)
        {
            parententrygameplayscript.questioningGameScript.gameObject.SetActive(false);
            parententrygameplayscript.InitialDialogueManager.gameObject.SetActive(true);
        }
        else if (allEntryGameplayStates == AllEntryGameplayStates.SecondDialogu)
        {
            parententrygameplayscript.questioningGameScript.gameObject.SetActive(false);
            parententrygameplayscript.SecondDialogue.gameObject.SetActive(true);
        }
        else if (allEntryGameplayStates == AllEntryGameplayStates.ThirdDialogu)
        {
            parententrygameplayscript.questioningGameScript.gameObject.SetActive(false);
            parententrygameplayscript.ThirdDialogue.gameObject.SetActive(true);
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
        if (allEntryGameplayStates == AllEntryGameplayStates.InitialDialogue)
        {
            if (parententrygameplayscript.InitialDialogueManager.isCompleted && !parententrygameplayscript.InitialDialogueManager.gameObject.activeInHierarchy)
            {
                animator.SetTrigger("DialogueOver");


            }
        }
        if (allEntryGameplayStates == AllEntryGameplayStates.QuestionMinigame)
        {
            currentTime += Time.deltaTime;
            if (currentTime > waitTime)
            {
                animator.SetTrigger("QuestioningDone");
            }

        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (allEntryGameplayStates == AllEntryGameplayStates.QuestionMinigame)
        {

            if (parententrygameplayscript.questioningGameScript.correctlyAnswered)
                parententrygameplayscript.score += questioningScore;
            else
                parententrygameplayscript.score -= questioningScore;
            parententrygameplayscript.questioningGameScript.gameObject.SetActive(false);
        }
        if (allEntryGameplayStates == AllEntryGameplayStates.QuestionMinigame2)
        {

            if (parententrygameplayscript.questioningGameScript2.correctlyAnswered)
                parententrygameplayscript.score += questioningScore;
            else
                parententrygameplayscript.score -= questioningScore;
            parententrygameplayscript.questioningGameScript2.gameObject.SetActive(false);
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
