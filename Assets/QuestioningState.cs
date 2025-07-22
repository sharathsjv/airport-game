using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class QuestioningState : MonoBehaviour
{
    CinemachineVirtualCamera ActiveCamera;

    // Start is called before the first frame update
    void Start()
    {
        ActiveCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
