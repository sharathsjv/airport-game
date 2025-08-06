using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    GameObject BaggageCounterState;
    public EntryGameplay entryGameplay;

    public float susmeter;

    void Awake()
    {
        instance = this;

        entryGameplay = FindAnyObjectByType<EntryGameplay>();
        entryGameplay.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
