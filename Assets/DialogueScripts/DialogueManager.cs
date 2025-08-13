using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    public DialoguesObject Sequence;
    [SerializeField]
    string currentDialogue;
    [SerializeField]
    int dialogueNumber, stringlength;
    [SerializeField]
    public bool isCompleted;

    [SerializeField]
    TMP_Text UIText;
    [SerializeField]
    InputAction NextDialogueInput;
    [SerializeField]
    PlayerInput playerInput;

    private void Awake()
    {

        UIText = GetComponentInChildren<TMP_Text>();

        playerInput = GetComponentInParent<PlayerInput>();
    }


    private void OnDisable()
    {
        playerInput.enabled = false;

        dialogueNumber = 0;
        currentDialogue = Sequence.Dialogues[dialogueNumber];
        FindAnyObjectByType<PlayerController>().GetComponent<PlayerInput>().enabled = true;
    }

    private void OnEnable()
    {
        FindAnyObjectByType<PlayerController>().GetComponent<PlayerInput>().enabled = false;

        isCompleted = false;

        playerInput.enabled = true;

        dialogueNumber = 0;
        currentDialogue = Sequence.Dialogues[dialogueNumber];
        UIText.text = currentDialogue;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //UIText = GetComponentInChildren<TMP_Text>();

        //playerInput = GetComponentInParent<PlayerInput>();

        dialogueNumber = 0;
        currentDialogue = Sequence.Dialogues[dialogueNumber];
        UIText.text = currentDialogue;

        if (!isCompleted)
        {
            this.gameObject.SetActive(false);
        }

        //NextDialogueInput.performed += context => {
        //    if (context.interaction is )
        //    {
        //        NextText();
        //    }


        //};

    }

    // Update is called once per frame
    void Update()
    {
        stringlength = Sequence.Dialogues.Length;
    }

    public void NextText(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            dialogueNumber++;
            if (dialogueNumber!=Sequence.Dialogues.Length) 
            {
                currentDialogue = Sequence.Dialogues[dialogueNumber];
                UIText.text = currentDialogue;
            }
            else
            {
                isCompleted = true;
                this.gameObject.SetActive(false);
            }
           
        }
        
        
    }
}
