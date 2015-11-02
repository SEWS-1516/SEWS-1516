using UnityEngine;
using System.Collections;

public class testfordoor : MonoBehaviour {

    public Camera cam;
    public RenderTexture mat;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        mat = cam.targetTexture;
	}
}
