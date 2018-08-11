using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonVisibility : MonoBehaviour {
    public GameObject cameraUICanvas; 
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    //this is the "motor" checking for updates
    void Update() {
        cameraUICanvas.SetActive(false);
        RaycastHit[] hit;
        Ray ray = new Ray(transform.position, transform.forward);
        hit = Physics.RaycastAll(ray, 100);
        if (hit.Length>0)
        {
            //this is a "for loop", repeats for all objects found
            for (int i = 0; i < hit.Length; i++)
            {
                //da juice. if it's a UI button, turn button on.
                if (hit[i].collider.gameObject.tag == "UI_Button")
                {
                    cameraUICanvas.SetActive(true);
                }
            }
        }
	}
}
