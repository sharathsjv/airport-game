using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField]
    public Collider playerCollider;
    [SerializeField]
    Vector3 moveinput;
    [SerializeField]
    Quaternion toTurnAngle;
    [SerializeField]
    public bool isCrouching;
    public Animator anim;
    [SerializeField]
    float walkSpeed;
    [SerializeField]
    int crouchSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        playerCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.transform.Translate(0, 0, moveinput.magnitude * Time.fixedDeltaTime * walkSpeed);
        toTurnAngle = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y + Mathf.Atan2(moveinput.x, moveinput.z) * Mathf.Rad2Deg, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, toTurnAngle, 50 * Time.fixedDeltaTime);

        
    }

    public void MovePlayer (InputAction.CallbackContext context)
    {
        moveinput = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);

        anim.SetFloat("Walking", moveinput.normalized.magnitude);
    }

    
}
