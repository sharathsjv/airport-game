using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.EventSystems;

public class EntryGameplay : MonoBehaviour
{
    bool isEntering;
    public QuestioningGameScript questioningGameScript, questioningGameScript2;
    public DialogueManager InitialDialogueManager, SecondDialogue, ThirdDialogue;
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

    public float score;
    PlayerController playerController;
    Animator EntryGameplayMachine;
    [SerializeField]
    EventSystem eventSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }

    void OnEnable()
    {
        eventSystem = FindFirstObjectByType<EventSystem>();
        GameManager.instance.entryGameplay = this;
        if (playerController == null)
        {
            playerController = FindFirstObjectByType<PlayerController>();
        }

        if (EntryGameplayMachine == null)
        {
            EntryGameplayMachine = GetComponent<Animator>();
        }

    }

    void OnDisable()
    {
        InitialDialogueManager.gameObject.SetActive(true);
        SecondDialogue.gameObject.SetActive(true);
        ThirdDialogue.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
