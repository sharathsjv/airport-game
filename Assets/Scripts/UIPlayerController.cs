using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIPlayerController : MonoBehaviour
{

    UIObject uiObject;
     
    InputAction action;

    [SerializeField] 
    public GameObject UIInteractable;

    [SerializeField]
    public Vector2 leftAnalogInput;
    [SerializeField]
    public float xButtonInput;


    [SerializeField]
    public float rotateSpeed = 1;

    public Vector3 FreeLookRotate, EmptyBottleRotate;

    // Update is called once per frame
    void Update()
    {

        FreeLookRotate = new Vector3(leftAnalogInput.x, 0, leftAnalogInput.y) * rotateSpeed * Time.deltaTime;
 
        EmptyBottleRotate = new Vector3(0, leftAnalogInput.x, 0) * rotateSpeed * Time.deltaTime;

    }

    public void onUIRotate(InputAction.CallbackContext context)
    {
        leftAnalogInput = context.ReadValue<Vector2>();
        
    }

    public void onUIInspected()
    {
        uiObject.isInspected = true;
    }

    public void onUIInspect(InputAction.CallbackContext context)
    {
        xButtonInput = context.ReadValue<float>();
    }

}
