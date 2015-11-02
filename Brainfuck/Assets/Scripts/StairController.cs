using UnityEngine;
using System.Collections;

public class StairController : MonoBehaviour {

    private Vector3 view;


    [Header("RotationsAttribute")]
    public float rotationspeed = 1; //Rotationsgeschwindigkeit
    public float maxAngle = 180; //noch nicht im einsatz
    public float minAngle = -180; // noch nicht im einsatz
    public float rotatelimit = 180; // rotiert hier 180Grad.

    [Header("RotationAchsen")] // um welche achse soll rotiert werden
    public bool x_rotation = false;
    public bool y_rotation = false;
    public bool z_rotation = false;

    [Header("GameObjects")]
    
    public GameObject stair;
    private GameObject player;
    public Camera camer; //Camera des Players für RayCast

    private bool isswitch = false; // überprüfe switches oder trittfalle bzw momentan leeres GameObject
    private bool triggert = false, isdrin = false; // triggert= switch oder button ; is drin reingelaufen;
    private Animator anima; //Animator benötigen der Switch und Button bzw noch andere

    private const string statename = "speed";
    private float counter, i, switch_v = -1;

    
	// Use this for initialization
	void Start () {

      if (this.gameObject.tag == "Button" || this.gameObject.tag == "Switch")  //überprüffe ob triggerbar //// ambesten noch ändern in tag == triggerbar
        {
            isswitch = true;
        }
      
        player = GameObject.FindGameObjectWithTag("Player");
        i = rotatelimit / rotationspeed;  //berechnet die schrittgeschwindigkeit der rotation
        if (isswitch)
            anima = this.gameObject.GetComponent<Animator>();  //Animator wird nur zugewiesen falls auch etwas is mit Animator also switch oder button oder usw
    }
	
	// Update is called once per frame
	void Update () {
       
            Ray ray = camer.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
                
        if (Physics.Raycast(ray, out hit, 20) && Input.GetKeyDown(KeyCode.E) ) //Raycast wird überprüfft ob es in der distance von 20 und dem drück von E unten einen collider erwischt
        {
            Debug.Log("E wurde gedrückt!!!");
            if (hit.collider.gameObject == this.gameObject && isswitch)
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
            
            if (z_rotation)
                stair.transform.Rotate(0, 0, rotationspeed, Space.Self);
            if (y_rotation)
                stair.transform.Rotate(0, rotationspeed, 0, Space.Self);
            if (x_rotation)
                stair.transform.Rotate(rotationspeed, 0, 0, Space.Self);
        
            if (counter == rotatelimit)
            {               
                triggert = false;
                isdrin = false;                
                counter = 0;
                switch_v *= -1;
            }
        }	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject==player&&!isswitch)
        {
            isdrin = true;
        }
    }

    void notWorkingSwitch()
    {
        //kommt noch?
    }
}
