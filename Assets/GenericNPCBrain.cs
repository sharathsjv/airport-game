using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements.Experimental;

public class GenericNPCBrain : MonoBehaviour
{
    [SerializeField]
    Animator _NPC_Master;

    [SerializeField]
    bool _isQueuing;

    [SerializeField]
    bool _isStationary;

    [SerializeField]
    public Transform testTargetTransform, testTargetTransform2, TargetTransform;

    [SerializeField]
    public NPCManager nPCManager;

    public Animator NPCMaster
    {
        set { _NPC_Master = value; }
        get { return _NPC_Master; }
    }

    public bool isQueuing
    {
        get { return isQueuing; }
        set
        {
            _isQueuing = value;
            if (value == true)
            {
                _NPC_Master.SetTrigger("Queuing");
            }
        }

    }

    public bool isStationary
    {
        get { return _isStationary; }
        set
        {
            _isStationary = value;
            if (value == true)
            {
                _NPC_Master.SetTrigger("QStationary");
            }
        }

    }

    void OnDisable()
    {
        GetComponentInParent<NPCManager>().GenericActors.Remove(this);
    }

    void OnEnable()
    {
        GetComponentInParent<NPCManager>().GenericActors.Add(this);
    }

    public NavMeshAgent navMeshAgent;

    void Awake()
    {
        _NPC_Master = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        NPCMaster = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
