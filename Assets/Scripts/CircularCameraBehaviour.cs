using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularCameraBehaviour : MonoBehaviour {

    public Vector3 centre;
    public float radius = 2f;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        this.transform.position = centre + this.transform.forward * radius;
    }
}
