using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestCamControl : MonoBehaviour {

    public float speedH = 2.0f;
    private float yaw = 0.0f;
    public Camera cam;
    private const float xpos = 55.0f;
    
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        cam.transform.eulerAngles = new Vector3(55f, yaw, 0f);
    }
}
