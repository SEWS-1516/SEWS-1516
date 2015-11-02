using UnityEngine;
using System.Collections;

public class DoorTeleport : MonoBehaviour {

    private Vector3 teleportto;
    public GameObject portpoint;
    private GameObject player;
    // Use this for initialization
    void Start ()
    {
        teleportto = portpoint.gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");	
	}	
	void Update ()
    {
	}

    void teleported()
    {
        player.transform.rotation = Quaternion.Euler(portpoint.gameObject.transform.localEulerAngles);
        player.transform.position = new Vector3(teleportto.x, teleportto.y, teleportto.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            teleported();
        }
    }
}
