using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FretHit : MonoBehaviour
{
    [SerializeField]
    Vector2 analogInput;
    [SerializeField]
    RhythmGameScript rhythmgamescript;

    enum FretType { Up,  Down, Left, Right };

    [SerializeField]
    FretType type;
    // Start is called before the first frame update
    void Start()
    {
        rhythmgamescript = GameObject.Find("Rhythm").GetComponent<RhythmGameScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerStay2D(Collider other)
    //{
    //    Debug.Log("Entered");
    //    if (other.gameObject.tag == "Fret")
    //    {
    //        //switch (type)
    //        //{
    //        //    case FretType.Up:
    //        //        if (analogInput.y > 0)
    //        //        {
    //        //            other.GetComponent<FretMover>().correctHit = true;

    //        //            other.gameObject.SetActive(false);
    //        //        }
    //        //        break;
    //        //    case FretType.Down:
    //        //        if (analogInput.y < 0)
    //        //        {
    //        //            other.GetComponent<FretMover>().correctHit = true;

    //        //            other.gameObject.SetActive(false);
    //        //        }
    //        //        break;
    //        //    case FretType.Left:
    //        //        if (analogInput.x < 0)
    //        //        {
    //        //            other.GetComponent<FretMover>().correctHit = true;

    //        //            other.gameObject.SetActive(false);
    //        //        }
    //        //        break;
    //        //    case FretType.Right:
    //        //        if (analogInput.x > 0)
    //        //        {
    //        //            other.GetComponent<FretMover>().correctHit = true;

    //        //            other.gameObject.SetActive(false);
    //        //        }
    //        //        break;

    //        //}

    //        if (type == FretType.Left)
    //        {
    //            if (analogInput.x < 0)
    //            {
    //                other.GetComponent<FretMover>().correctHit = true;

    //                other.gameObject.SetActive(false);
    //            }
    //        }
    //    }
    //}

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Entered");
        if (other.gameObject.tag == "Fret")
        {
            switch (type)
            {
                case FretType.Up:
                    if (analogInput.y > 0)
                    {
                        other.GetComponent<FretMover>().correctHit = true;

                        other.gameObject.SetActive(false);
                    }
                    break;
                case FretType.Down:
                    if (analogInput.y < 0)
                    {
                        other.GetComponent<FretMover>().correctHit = true;

                        other.gameObject.SetActive(false);
                    }
                    break;
                case FretType.Left:
                    if (analogInput.x < 0)
                    {
                        other.GetComponent<FretMover>().correctHit = true;

                        other.gameObject.SetActive(false);
                    }
                    break;
                case FretType.Right:
                    if (analogInput.x > 0)
                    {
                        other.GetComponent<FretMover>().correctHit = true;

                        other.gameObject.SetActive(false);
                    }
                    break;

            }
        }
    }

        private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag=="Fret")
        {
            if (other.GetComponent<FretMover>().correctHit == true)
            {
                rhythmgamescript.score++;
            }
            else
            {
                rhythmgamescript.score--;
            }
        }
        
    }

    public void onInputDPadLeft(InputAction.CallbackContext context)
    {
        analogInput = context.ReadValue<Vector2>(); 
    }
}
