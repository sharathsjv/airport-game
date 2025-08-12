using Cinemachine;
using UnityEngine;
using UnityEngine.WSA;

public class CameraChanger : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera currentCamera, toActivate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            currentCamera = FindAnyObjectByType<CinemachineVirtualCamera>();
            if (currentCamera != toActivate)
            {
                currentCamera.gameObject.SetActive(false);
                toActivate.gameObject.SetActive(true);


            }
        }   
    }
}
