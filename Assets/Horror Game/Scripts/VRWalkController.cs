using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class VRWalkController : MonoBehaviour
{

    public bool walkMode;
    public float speed = 4.0f;
    public bool moveForward;
    public float direction = 1.0f;
    private CharacterController controller;
    public Transform vrMainCamera;
    private float stp;
    public bool pauseMovement;
    private float PLAYER_STANDARD_HEIGHT = -0.8f;
    public Transform playerTrans;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        vrMainCamera = Camera.main.transform;
        playerTrans = this.transform;
        Input.gyro.enabled = true;
    }

    void FixedUpdate()
    {
        if (!pauseMovement)
        {
            if (walkMode)
            {
                if (Input.GetMouseButton(0))
                {
                    moveForward = true;
                    direction = 1.0f;
                }
                //else if (Input.GetMouseButton(1))
                //{
                //    moveForward = true;
                //    direction = -0.7f;
                //}
                else
                {
                    moveForward = false;
                    controller.SimpleMove(Vector3.zero);
                }

                if (moveForward)
                {
                    Vector3 forward = vrMainCamera.TransformDirection(Vector3.forward);
                    controller.SimpleMove(forward * speed * direction);
                }
            }
            else
            {
                if (stp <= 0.0f)
                {
                    moveForward = false;
                    if (Vector3.Magnitude(Input.gyro.rotationRate) < 0.5f)
                        if (Vector3.Magnitude(Input.acceleration) > 1.1f)
                            if (stp <= 0.0f)
                                stp = 1.0f;
                }
                else
                {
                    moveForward = true;
                    Vector3 forward = vrMainCamera.TransformDirection(Vector3.forward);
                    controller.SimpleMove(forward * speed);
                    stp -= speed * Time.deltaTime;
                }
            }
        }
    }

    public void ReturnPlayer(Transform returnPoint)
    {
        transform.position = new Vector3(returnPoint.position.x, PLAYER_STANDARD_HEIGHT, returnPoint.position.z);
    }

    public void DisablePlayer()
    {
        moveForward = false;
        pauseMovement = true;
    }

    public void EnablePlayer()
    {
        pauseMovement = false;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "FBSD")
    //    {
    //        speed = 0.02f;
    //        Debug.Log("SLOW DOWN!");
    //    }
    //    else if (other.tag == "FBSD1")
    //    {
    //        Debug.Log("SLOW DOWNNNNNNN!");
    //        speed = 0.01f;
    //    }
    //    else if (other.tag == "FBST")
    //    {
    //        Debug.Log("STEADY!");
    //        speed = 0.2f;
    //    }
    //    else if (other.tag == "FBSS")
    //    {
    //        Debug.Log("GOOOOOO!!!!");
    //        speed = 1.5f;
    //    }
    //    else if (other.tag == "NORM")
    //    {
    //        speed = 3f;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FBSD")
        {
            speed = 0.01f;
            Debug.Log("SLOW DOWN!");
        }
        else if (other.tag == "FBSD1")
        {
            Debug.Log("SLOW DOWNNNNNNN!");
            speed = 0.007f;
        }
        else if (other.tag == "FBST")
        {
            Debug.Log("STEADY!");
            speed = 0.05f;
        }
        else if (other.tag == "FBSS")
        {
            Debug.Log("GOOOOOO!!!!");
            speed = 1.2f;
        }
        else if (other.tag == "NORM")
        {
            speed = 2.4f;
        }
    }

}
