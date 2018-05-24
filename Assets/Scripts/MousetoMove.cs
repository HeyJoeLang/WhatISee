using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousetoMove : MonoBehaviour {
    public float sensitivityX = 4;
    public float sensitivityY = 2;

    private float rotationY = 0f;
    private float minimumY = -60f;
    private float maximumY = 60f;

    void Update()
    {
        if (Application.isEditor)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += (Input.GetAxis("Mouse Y") * sensitivityY);
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        }
    }
}
