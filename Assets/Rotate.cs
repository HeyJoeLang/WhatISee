using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float rotValue = Mathf.PI * 0.01f;
    public float speed = 3f;

	void Update () {
        this.transform.Rotate(this.transform.up, Mathf.PingPong(Time.timeSinceLevelLoad * speed, rotValue*2f) - rotValue);
	}
}
