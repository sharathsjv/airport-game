using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class EntryGameplay : MonoBehaviour
{
    bool isEntering;
    public QuestioningGameScript questioningGameScript;
    public DialogueManager InitialDialogueManager,PostCorrectDialogue, PostWrongDialogue;
    public bool _isEntering
    {
        get { return isEntering; }
        set
        {
            isEntering = value;
            if (value == true)
            {

            }
        }
    }
    PlayerController playerController;
    Animator EntryGameplayMachine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        questioningGameScript = FindAnyObjectByType<QuestioningGameScript>();
    }

    void OnEnable()
    {

        GameManager.instance.entryGameplay = this;
        if (playerController == null)
        {
            playerController = FindFirstObjectByType<PlayerController>();
        }

        if (EntryGameplayMachine == null)
        {
            EntryGameplayMachine = GetComponent<Animator>();
        }

        if (questioningGameScript == null)
        {
            questioningGameScript = FindAnyObjectByType<QuestioningGameScript>();
        }


    }
    
    // Update is called once per frame
        void Update()
        {

        }
}
