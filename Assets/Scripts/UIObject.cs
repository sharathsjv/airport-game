using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UIObject : MonoBehaviour
{



    [SerializeField]
    public UIPlayerController UIPlayerController;

    RaycastHit hit;
    public Camera UIObjectCamera;
    [SerializeField]
    public GameObject Interactable, Interactable2;
    [SerializeField]
    public GameObject UIActionSign,UITiltSign;
    [SerializeField]
    public GameObject UIActionMenu;
    [SerializeField]
    public GameObject VerticalBottleTransform, LookDownTransform;

    [SerializeField]
    public bool isInspected, isRemoved;

    public Ray ray;

    [SerializeField]
    Vector3 RayDirection;

    [SerializeField]
    float angle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RayCalculation();
  

        if (angle > 0.92 && isInspected ==false)
        {
            UIActionSign.SetActive(true);
            if (UIPlayerController.xButtonInput > 0)
            {
                isInspected = true;
            }
            
        }
        else
        {
            UIActionSign.SetActive(false);
        }


    }

    public void TiltObject(GameObject ObjectToTilt)
    {
        ObjectToTilt.transform.Rotate(transform.right, 2);
    }

    public void IsRemoved()
    {
        isRemoved = true;
    }

    public void RayCalculation()
    {
        RayDirection = UIObjectCamera.transform.position - Interactable.transform.position;
        angle = Vector3.Dot(Interactable.transform.up, RayDirection.normalized);
    }
}
