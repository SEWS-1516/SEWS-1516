using UnityEngine;
using System.Collections;

public class ChangingGravity : MonoBehaviour {

    public float gravRayLength = 10.0f;
    public float cameraToGravAlignmentTime = 1.0f;

    private Vector3 gravObjAlignment;
    private Ray gRay;                                                      
    private RaycastHit[] gRayHitArray;
    private RaycastHit gRayShortestHit;

    void Start () {
	
	}
	
	//raycast in the direction of the Gravitation(grav)
    //on hit changes the direction of grav to normal of the hit plane
    //Impications: Every plane has its own grav
	void Update ()
    {
        gRay = new Ray(this.transform.position, Physics.gravity);
        gRayHitArray = Physics.RaycastAll(gRay, gravRayLength);
        //TODO own function
        if (gRayHitArray.Length != 0)
        {
            gRayShortestHit = gRayHitArray[0];
            for(int i = 0; i < gRayHitArray.Length; i++)
            {
                if (gRayHitArray[i].distance < gRayShortestHit.distance)
                    gRayShortestHit = gRayHitArray[i];
            }
            Physics.gravity = -gRayShortestHit.normal * 5;                           //sets gravity to normal of the raycast hit
            print(gRayShortestHit.normal.x + " " + gRayShortestHit.normal.y + " " + gRayShortestHit.normal.z);
        }
        else
        {
            //maybe needed
        }
        //Code for changing the alignment of the grav object

        this.transform.up = Vector3.Lerp(transform.up, -Physics.gravity, Time.deltaTime * cameraToGravAlignmentTime);
    }
}
