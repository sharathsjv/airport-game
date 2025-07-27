using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager instance;


    [SerializeField]
    List<GenericNPCBrain> _GenericActors;
    [SerializeField]
    List<QueueScript> _Queues;

    public List<QueueScript> Queues
    {
        get { return _Queues; }
        set { _Queues = value; }
    }

    public List<GenericNPCBrain> GenericActors
    {
        get { return _GenericActors; }
        set { _GenericActors = value; }
    }

    void Awake()
    {
        instance = this;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
