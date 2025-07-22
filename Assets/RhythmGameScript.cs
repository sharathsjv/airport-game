using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Composites;

public class RhythmGameScript : MonoBehaviour
{

    [SerializeField]
    public float beatsPerMinute = 150f, secondsPerBeat;
    public float currentBeatTime, currentTime;

    [SerializeField]
    GameObject FretEnd1, FretEnd2, FretEnd3, FretEnd4;

    [SerializeField]
    public enum FretNumber { First, Second, Third, Fourth};

    [SerializeField]
    GameObject FretToInitialize;

    [SerializeField]
    Transform Fretstart;

    [SerializeField]
    public int beatCounter, fret1BeatInterval;

    [SerializeField]
    public bool beatHit;

    [SerializeField]
    public float score;

    // Start is called before the first frame update
    void Start()
    {
        secondsPerBeat = 60 / beatsPerMinute;
    }

    // Update is called once per frame
    void Update()
    {
        //currenttime += Time.deltaTime;
        //if (currenttime >= secondsPerBeat)
        //{
        //    beatCounter += 1;
        //    currenttime = 0;
        //}
            
    }

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        currentBeatTime += Time.deltaTime;
        if (currentBeatTime >= secondsPerBeat+0.05)
        {
            beatCounter += 1;
            currentBeatTime = 0;
            beatHit = true;
            fret1BeatInterval--;

        }
        else
        {
            beatHit =false;
        }
        
    }

    //public void Spawn(int fretNumber)
    //{
        
    //    Debug.Log(fret1BeatInterval);
    //    if (fret1BeatInterval >0)
    //    {
    //        switch(fretNumber) 
    //        {
    //            case 1:
    //                Debug.Log("Spawning in 1");
    //                Instantiate(FretToInitialize, FretEnd1.transform);
    //                break;
    //            case 2:
    //                Debug.Log("Spawning in 2");
    //                Instantiate(FretToInitialize, FretEnd2.transform);
    //                break;
    //            case 3:
    //                Debug.Log("Spawning in 3");
    //                Instantiate(FretToInitialize, FretEnd3.transform);
    //                break;
    //            case 4:
    //                Debug.Log("Spawning in 4");
    //                Instantiate(FretToInitialize, FretEnd4.transform);
    //                break;
    //        }
            
    //    }
    //}
}



