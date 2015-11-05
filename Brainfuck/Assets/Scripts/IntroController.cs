using UnityEngine;
using System.Collections;

public class IntroController : MonoBehaviour {
    public Material mat_start, mat_extra, mat_quit;
    private int index = 0;
	void Start ()
    {
       // mat_start = GameObject.FindGameObjectWithTag("Start").GetComponent<Material>();
       // mat_extra = GameObject.FindGameObjectWithTag("Extra").GetComponent<Material>();
       // mat_quit = GameObject.FindGameObjectWithTag("Quit").GetComponent<Material>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Debug.Log(index);
        if (index > 2) {
            index = 0; }
        if (index < 0)
        {
            index = 2;
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            index--;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            index++;
        }
        
            mat_start.color = Color.black;
        mat_extra.color = Color.black;
        mat_quit.color = Color.black;
        switch (index)
        {
           case 0:
                mat_start.color = Color.red;
                    if (Input.GetKeyDown(KeyCode.Return))
                        Application.LoadLevel(1);
                break;
           case 1:
                mat_extra.color = Color.red;
                    if (Input.GetKeyDown(KeyCode.Return))
                        Debug.Log("Gib Extras aus");
                break;
           case 2:
                mat_quit.color = Color.red;
                    if (Input.GetKeyDown(KeyCode.Return))
                        Application.Quit();
                break;
            default:
                break;          

        }
        

    }
}
