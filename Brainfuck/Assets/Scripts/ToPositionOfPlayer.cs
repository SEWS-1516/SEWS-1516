using UnityEngine;
using System.Collections;

public class ToPositionOfPlayer : MonoBehaviour {

    public GameObject player;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = player.transform.position;
    }
}
