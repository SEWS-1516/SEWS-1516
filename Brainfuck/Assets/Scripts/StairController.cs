using UnityEngine;
using System.Collections;

public class StairController : MonoBehaviour
{

    private Vector3 view;


    [Header("RotationsAttribute")]
    public Vector3 rotationspeed = new Vector3(0, 0, 1); //Rotationsgeschwindigkeit
    public Vector3 maxAngle = new Vector3(0, 0, 180); //noch nicht im einsatz   
    public Vector3 rotatelimit = new Vector3(0, 0, 180); // rotiert hier 180Grad.

    [Header("RotationAchsen")] // um welche achse soll rotiert werden
    public bool x_rotation = false;
    public bool y_rotation = false;
    public bool z_rotation = false;

    [Header("GameObjects")]

    public GameObject stair;
    private GameObject player;
    public Camera camer; //Camera des Players für RayCast

    [Header("SchalterArt")]

    public bool isswitch = false; // überprüfe switches oder trittfalle bzw momentan leeres GameObject
    public bool groundplate = false;
    public bool getanima = false;

    private bool triggert = false;
    private bool isdrin = false; // triggert= switch oder button ; is drin reingelaufen;
    private Animator anima; //Animator benötigen der Switch und Button bzw noch andere

    private Vector3 beginning;
    private Vector3 counter;
    private const string statename = "speed";
    private float i, switch_v = -1;
    private int index = 1;


    // Use this for initialization
    void Start()
    {

        if (this.gameObject.tag == "Button" || this.gameObject.tag == "Switch")  //überprüffe ob triggerbar //// ambesten noch ändern in tag == triggerbar
        {
            isswitch = true;
        }

        if (this.gameObject.tag == "GroundTigger")
        {
            groundplate = true;
        }

        beginning = stair.transform.position;

        player = GameObject.FindGameObjectWithTag("Player");
        //  i = rotatelimit / rotationspeed;  //berechnet die schrittgeschwindigkeit der rotation
        if (getanima)
            anima = this.gameObject.GetComponent<Animator>();  //Animator wird nur zugewiesen falls auch etwas is mit Animator also switch oder button oder usw
    }

    // Update is called once per frame
    void Update()
    {

        //if((Mathf.Abs(Max_Angle)+Mathf.Abs(beginning)) % (Mathf.Abs(beginning) + (Math.Abs(rotatelimit)*index)))
        {
            rotationspeed = -rotationspeed;
            index = 1;
        }

        Ray ray = camer.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 20) && Input.GetKeyDown(KeyCode.E)) //Raycast wird überprüfft ob es in der distance von 20 und dem drück von E unten einen collider erwischt
        {
            Debug.Log("E wurde gedrückt!!!");
            if (hit.collider.gameObject == this.gameObject && isswitch)
            {
                Debug.Log("triggert");
                triggert = true;
                switch_v = 1;
                //anima.SetFloat(statename, switch_v);
            }
            else { switch_v = 0; }
        }

        if (triggert || isdrin)
        {

            anima.SetFloat(statename, switch_v);
            // counter += Mathf.Abs(rotationspeed);


            stair.transform.Rotate(rotationspeed, Space.Self);

            if (counter == rotatelimit)
            {
                index++;
                triggert = false;
                isdrin = false;
                counter = new Vector3(0, 0, 0);
                switch_v *= -1;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && !isswitch)
        {
            if (groundplate)
            {
                //anima.SetFloat(statename, switch_v);
                switch_v = 1;
            }
            else
            {
                switch_v = 0;
            }
            isdrin = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        switch_v *= -1;
    }

    void notWorkingSwitch()
    {
        //kommt noch?
    }
}
