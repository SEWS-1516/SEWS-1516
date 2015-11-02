using UnityEngine;
using System.Collections;

//fkt vorerst nur mit einer richtung 3 

public class PlattformMove : MonoBehaviour {

    public Vector3 maximum = new Vector3(0, 0, 0);
    public Vector3 velocity = new Vector3(0, 0, 0);
    private Vector3 beginning = new Vector3(0, 0, 0);
    private Vector3 tmpvec = new Vector3(0, 0, 0);

    public bool droppin = false, breakable = false, movable = false;
    private bool onPlat = false;
    
    private GameObject Player;


    // Use this for initialization
    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        beginning = this.gameObject.transform.position;
        tmpvec.x = Mathf.Abs(beginning.x);

	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("Tomporary"+tmpvec);
        Debug.Log("Beginning:"+beginning);

        tmpvec.x += Mathf.Abs(velocity.x);
        tmpvec.y += Mathf.Abs(velocity.y);
        tmpvec.z += Mathf.Abs(velocity.z);

        if (movable)
        {
            maximumreached();
            this.transform.position += velocity;
            if (onPlat)
            {
                Player.transform.position += velocity;
            }
        }
	
	}

    void  maximumreached()
    {
        Debug.Log(beginning);
        if (Mathf.Abs(tmpvec.x) - Mathf.Abs(beginning.x)>=Mathf.Abs(maximum.x))
        {
            Debug.Log("MaxReached");
            velocity.x = -velocity.x;
            tmpvec.x = Mathf.Abs(beginning.x) - Mathf.Abs(maximum.x);
            return;
        }
        if (Mathf.Abs(tmpvec.y) - Mathf.Abs(beginning.y) >= Mathf.Abs(maximum.y))
        {
            velocity.y = -velocity.y;
            tmpvec.y = Mathf.Abs(beginning.y) - Mathf.Abs(maximum.y);
            return;
        }
        if (Mathf.Abs(tmpvec.z) - Mathf.Abs(beginning.z) >= Mathf.Abs(maximum.z))
        {
            velocity.z = -velocity.z;
            tmpvec.z = Mathf.Abs(beginning.z) - Mathf.Abs(maximum.z);
            return;
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.gameObject)
        {
            onPlat = true;
        }
    }

    void OnTriggerExit(Collider other)
    {      
            onPlat = false;        
    }
}
