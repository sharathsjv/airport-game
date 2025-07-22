using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FretMover : MonoBehaviour
{
    [SerializeField]
    Transform FretTransform;
    [SerializeField]
    float speed = 2;
    [SerializeField]
    int currentBeat;
    [SerializeField]
    RhythmGameScript gameScript;
    [SerializeField]
    bool isMoved;
    [SerializeField]
    public bool correctHit;
    // Start is called before the first frame update
    void Start()
    {
        FretTransform = GetComponent<Transform>();
        gameScript = GameObject.Find("Rhythm").GetComponent<RhythmGameScript>();
        currentBeat = gameScript.beatCounter;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentBeat!=gameScript.beatCounter)
        {
            FretTransform.transform.position += new Vector3(0, -1, 0);
            currentBeat++;
        }
        
    }
}
