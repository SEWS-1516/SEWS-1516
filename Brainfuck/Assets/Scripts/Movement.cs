using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    public float speed = 6.0F;

    public float gravityOnGround = 20.0F;
    public float gravityInAir = 100.0f;

    public Vector3 CenterOfMassOffset = new Vector3(0f, 0f, 0f);

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float optDist = 1f;
    public float acceleration = 1f;

    private ConstantForce cForce;
    private Camera mainCamera;
    private Rigidbody rBody;

    private bool isGrounded;

    private RaycastHit hit;

    private float forward_Speed;
    private float side_Speed;

    private Vector3 MoveDirection;
    private Vector3 v3Cam;
    private Vector3 v3Player;
    void Start()
    {

        rBody = GetComponent<Rigidbody>();
        rBody.centerOfMass = CenterOfMassOffset + rBody.centerOfMass;
        mainCamera = GetComponentInChildren<Camera>();
        isGrounded = true;
        v3Cam = new Vector3(0f, 0f, 0f);
        v3Player = new Vector3(0f, 0f, 0f);

    }

    void FixedUpdate()
    {
        if (isGrounded)
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                if (Input.GetAxis("Vertical") > 0 && forward_Speed < speed)
                {
                    //forward_Speed += acceleration * Time.deltaTime;
                    rBody.velocity = transform.forward * speed;
                    //rBody.velocity = transform.forward * speed * Time.deltaTime;
                }

                else if (Input.GetAxis("Vertical") < 0 && -forward_Speed < speed)
                {
                    //forward_Speed -= acceleration * Time.deltaTime;
                    rBody.velocity = transform.forward * speed;
                    //rBody.velocity = transform.forward * -speed * Time.deltaTime;
                }


            }
            else
            {
                forward_Speed = 0;
            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    //side_Speed += acceleration * Time.deltaTime;
                    rBody.velocity = transform.right * speed;
                }

                else if (Input.GetAxis("Horizontal") < 0)
                {
                    //side_Speed -= acceleration * Time.deltaTime;
                    rBody.velocity = transform.right * -speed;
                }

            }
            else
            {
                side_Speed = 0;
            }
        }
        else
        {
            forward_Speed = 0;
            side_Speed = 0;
        }

        MoveDirection = new Vector3(0, 0, 0);
        if (side_Speed != 0 || forward_Speed != 0)
        {
            if (side_Speed != 0)
            {
                //MoveDirection = transform.right * side_Speed;
            }
            if (forward_Speed != 0)
            {
                //MoveDirection += transform.forward * forward_Speed;
            }
        }

        //rBody.velocity = MoveDirection;


        if (Input.GetAxis("Mouse X") != 0)
        {
            transform.RotateAround(transform.up, (Input.GetAxis("Mouse X") / 10 * sensitivityX));
        }
        if (Input.GetAxis("Mouse Y") != 0)
        {
            v3Cam.x -= (Input.GetAxis("Mouse Y") * sensitivityY);
            mainCamera.transform.localRotation = Quaternion.Euler(v3Cam);
        }
        Gravity();

    }

    void Gravity()
    {
        if (isGrounded)
        {
            Debug.Log("grounded");
            rBody.AddRelativeForce(new Vector3(0f, -gravityOnGround, 0f));
        }
        else
        {
            Debug.Log("Air");
            rBody.velocity = new Vector3(0, 0, 0);
            rBody.AddRelativeForce(new Vector3(0f, -gravityInAir, 0f));
        }
        isGrounded = false;
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}

