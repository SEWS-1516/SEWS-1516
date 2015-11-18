using UnityEngine;
using System.Collections;

//fkt vorerst nur mit einer richtung 3 

public class PlattformMove : MonoBehaviour
{

    public Vector3 maximum = new Vector3(0, 0, 0);
    public Vector3 velocity = new Vector3(0, 0, 0);
    private Vector3 beginning = new Vector3(0, 0, 0);
    private Vector3 tmpvec = new Vector3(0, 0, 0);

    public bool droppin = false, breakable = false, movable = false;
    private bool onPlat = false, falling = false, breaked = false;
    private int breakcounter = 0;

    private GameObject Player;

    IEnumerator wair_fall()
    {
        droppin = false;
        yield return new WaitForSeconds(3.0f);
        falling = true;
    }
    IEnumerator wair_break()
    {
        yield return new WaitForSeconds(2.0f);
        breakcounter++;
        if (breakcounter == 5)
        {
            breaked = true;
        }
    }

   
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        beginning = this.gameObject.transform.position;
        tmpvec.x = Mathf.Abs(beginning.x);
    }

    // Update is called once per frame
    void Update()
    {

        // tmpvec.x += Mathf.Abs(velocity.x);
        // tmpvec.y += Mathf.Abs(velocity.y);
        // tmpvec.z += Mathf.Abs(velocity.z);

        if (droppin)
        {
            StartCoroutine(wair_fall());
        }

        if (falling)
        {
            velocity.y = -velocity.y;
        }

        if (movable)
        {
            if (!falling)
            {
                maximumreached();
            }
            this.transform.position += velocity;
            if (onPlat)
            {
                Player.transform.position += velocity;
            }
        }
    }

    void maximumreached()
    {
        Debug.Log(beginning);
        if (Mathf.Abs(tmpvec.x) - Mathf.Abs(beginning.x) >= Mathf.Abs(maximum.x))
        {
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

    void fallable()
    {
        StartCoroutine(wair_fall());
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

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Player.gameObject)
        {
            if (breakable)
            {
                StartCoroutine(wair_break());
            }
        }
    }
}
