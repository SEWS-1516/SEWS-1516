using UnityEngine;
using System.Collections;

public class TrapController : MonoBehaviour {


    private GameObject player;
    private Animator anim;
    private bool trigger;
    private const string staten = "speed";
    private float speed = 1.0f;

    
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        //player.GetComponent<PlayerHealth>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (trigger)
        {
            anim.SetFloat("speed", 1.0f);
            
        }
	
	}


    void takedmg()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            trigger = true;
        }
    }


}
