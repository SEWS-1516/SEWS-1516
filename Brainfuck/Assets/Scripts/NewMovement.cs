using UnityEngine;
using System.Collections;

public class NewMovement : MonoBehaviour {

    // Use this for initialization
    public float impulse = 4;

    private Vector3 force;
    private Rigidbody rbPlayer;
    private Vector3 dir;

    void Start ()
    {

    }

    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Simple movement script
        //TODO Rework/improve to match human movement
        //TODO Change Gravity script
       

        dir = Camera.main.transform.TransformDirection(new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal")));
        //this.GetComponent<Rigidbody>().AddTorque(dir * impulse);
        this.GetComponent<Rigidbody>().angularVelocity = dir * impulse;
        /*dir += new Vector3(Physics.gravity.x * dir.x, Physics.gravity.y * dir.y, Physics.gravity.z * dir.z);

        rbPlayer.AddForce(dir * impulse * Time.deltaTime);*/
    }
}
