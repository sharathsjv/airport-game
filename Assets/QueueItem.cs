using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class QueueItem : MonoBehaviour
{
    [SerializeField]
    public GenericNPCBrain _ChosenOne;

    public bool isPlayerOccupied;

    public GenericNPCBrain ChosenOne
    {
        get { return _ChosenOne; }
        set
        {
            _ChosenOne = value;
            if (_ChosenOne != null && this.isActiveAndEnabled)
            {
                _ChosenOne.isQueuing = true;
                _ChosenOne.TargetTransform = transform;
                _ChosenOne.CurrentNumberInQueue = this;

            }

        }
    }
    public QueueScript ParentQueueScript;
    public int queueNumber;

    public bool filled;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        filled = false;
        ChosenOne.isQueuing = true;
        ChosenOne.TargetTransform = transform;
        ChosenOne.CurrentNumberInQueue = this;
    }

    void OnEnable()
    {
        ParentQueueScript = GetComponentInParent<QueueScript>();
        _ChosenOne.isQueuing = true;
        _ChosenOne.TargetTransform = transform;
        _ChosenOne.CurrentNumberInQueue = this;
        ParentQueueScript.QueuedUpPeople.Add(_ChosenOne);
    }

    public void ReArrangeQueue()
    {
        MoveUpTheQueue();

        ParentQueueScript.CurrentActiveLastItem--;
    }

    void OnDisable()
    {
        ParentQueueScript.queueItems.Remove(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        filled = true;
        if (other.tag == "NPC")
        {

            if (other.GetComponent<GenericNPCBrain>() == _ChosenOne)
            {
                other.GetComponent<GenericNPCBrain>().isStationary = true;

                if (this == ParentQueueScript.queueItems[ParentQueueScript.CurrentActiveLastItem])
            {
                ParentQueueScript.queueItems[queueNumber].gameObject.SetActive(true);
                ParentQueueScript.CurrentActiveLastItem++;



            }
            }
            

        }

        if (other.tag == "Player")
        {
            if (_ChosenOne != null)
            {
                MoveBackInQueue();
                _ChosenOne = null;
                isPlayerOccupied = true;
                ParentQueueScript.queueItems[queueNumber].gameObject.SetActive(true);
                ParentQueueScript.CurrentActiveLastItem++;
                if (queueNumber == 1)
                {
                    GameManager.instance.entryGameplay.gameObject.SetActive(true);
                }
            }


        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerOccupied = true;
            filled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.tag == "NPC")   
            filled = false;
        if (other.tag == "Player")
            isPlayerOccupied = false;
    }

    public void MoveBackInQueue()
    {
        GenericNPCBrain temp = ParentQueueScript.queueItems[1]._ChosenOne;
        Debug.Log(ParentQueueScript.queueItems.Capacity);
        for (int i = ParentQueueScript.queueItems.Capacity - 1; i >= 0; i--)
        {
            if (i > queueNumber-1)
            {
                ParentQueueScript.queueItems[i].ChosenOne = ParentQueueScript.queueItems[i - 1].ChosenOne;
            }
        }
    }

    public void MoveUpTheQueue()
    {

        //GenericNPCBrain temp = ParentQueueScript.queueItems[1]._ChosenOne;
        //Debug.Log(ParentQueueScript.queueItems.Capacity);
        //for (int i = 0; i < ParentQueueScript.queueItems.Capacity - 1; i++)
        //{


        //ParentQueueScript.queueItems[i].ChosenOne = ParentQueueScript.queueItems[i + 1].ChosenOne;

        //}

        ParentQueueScript.queueItems[queueNumber - 2]._ChosenOne = _ChosenOne;
        
    }



    void FindNPCToQueue()
    {
        foreach (var a in NPCManager.instance.GenericActors)
        {
            if (a.isQueuing == false)
            {
                _ChosenOne = a;
                _ChosenOne.TargetTransform = transform;
                break;

            }

        }

    }
    
    
}
