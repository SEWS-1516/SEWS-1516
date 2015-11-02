using UnityEngine;
using System.Collections;

public class StairController : MonoBehaviour {

    private Vector3 view;

    public Camera cam;
    private GameObject player;
    public GameObject stair, trigger_go;
    private bool triggert = false, isdrin = false;
    private Animator anima;

    private const string statename = "speed";
    public float rotationspeed = 1, maxAngle = 180, minAngle = -180, rotatelimit = 180;
    private float counter, i, switch_v = 1;

    
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        i = rotatelimit / rotationspeed;
        anima = trigger_go.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,20) && Input.GetKeyDown(KeyCode.E))
        {
            
            if (hit.collider.gameObject == trigger_go)
            {
                Debug.Log("triggert");
                triggert = true;
                anima.SetFloat(statename, switch_v);
            }
        }
        Debug.Log(switch_v);

        if (triggert || isdrin)
        {
            counter += rotationspeed;
            stair.transform.Rotate(0, 0, rotationspeed, Space.Self);
            if (counter == rotatelimit)
            {               
                triggert = false;
                isdrin = false;                
                counter = 0;
                switch_v = -switch_v;
            }
        }	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject==player)
        {
            isdrin = true;
        }
    }

    void notWorkingSwitch()
    {
        //kommt noch?
    }
}
