using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class QueueItem : MonoBehaviour
{
    [SerializeField]
    public GenericNPCBrain ChosenOne;
    QueueScript ParentQueueScript;
    public int queueNumber;

    public bool filled;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        filled = false;
        ChosenOne.isQueuing = true;
        ChosenOne.TargetTransform = transform;
    }

    void OnEnable()
    {
        ParentQueueScript = GetComponentInParent<QueueScript>();
        ChosenOne.isQueuing = true;
        ChosenOne.TargetTransform = transform;
        ParentQueueScript.QueuedUpPeople.Add(ChosenOne);
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

            if (other.GetComponent<GenericNPCBrain>() == ChosenOne)
            {
                other.GetComponent<GenericNPCBrain>().isStationary = true;
            }
            if (this == ParentQueueScript.queueItems[ParentQueueScript.CurrentActiveLastItem])
            {
                ParentQueueScript.queueItems[ParentQueueScript.CurrentActiveLastItem + 1].gameObject.SetActive(true);
                ParentQueueScript.CurrentActiveLastItem++;



            }
            
        }

        if (other.tag == "Player")
        {
            if (ChosenOne != null)
            {
                ReorderQueue();
                ChosenOne = null;
                ParentQueueScript.queueItems[queueNumber].gameObject.SetActive(true);
                ParentQueueScript.CurrentActiveLastItem++;
            }
            

        }
    }

    void ReorderQueue()
    {
        GenericNPCBrain temp = ParentQueueScript.queueItems[1].ChosenOne;
        Debug.Log(ParentQueueScript.queueItems.Capacity);
        for (int i = ParentQueueScript.queueItems.Capacity-1; i >= 0; i--)
        {
            if (i > 0)
            {
                ParentQueueScript.queueItems[i].ChosenOne = ParentQueueScript.queueItems[i-1].ChosenOne;
            }
        }
    }

    

    void FindNPCToQueue()
    {
        foreach (var a in NPCManager.instance.GenericActors)
        {
            if (a.isQueuing == false)
            {
                ChosenOne = a;
                ChosenOne.TargetTransform = transform;
                break;

            }
            
        }

    }
}
