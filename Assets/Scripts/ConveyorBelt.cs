using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField]
    float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        collision.rigidbody.AddForce(transform.right * speed *Time.fixedDeltaTime, ForceMode.Force);
    }
}
