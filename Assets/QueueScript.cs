using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class QueueScript : MonoBehaviour
{

    public List<GenericNPCBrain> QueuedUpPeople;

    [SerializeField]
    List<QueueItem> _queueItems;

    [SerializeField]
    GenericNPCBrain ChosenOne;
    [SerializeField]
    public int CurrentActiveLastItem;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var a in queueItems)
        {
            if (a.isActiveAndEnabled)
            {
                break;

            }
            CurrentActiveLastItem++;
        }
    }

    void OnEnable()
    {
        if (NPCManager.instance != null)
        {
            NPCManager.instance.Queues.Add(this);

        }
    }

    void OnDisable()
    {
        queueItems.Clear();
    }

    public List<QueueItem> queueItems
    {
        get { return _queueItems; }
        set
        {
            _queueItems = value;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
