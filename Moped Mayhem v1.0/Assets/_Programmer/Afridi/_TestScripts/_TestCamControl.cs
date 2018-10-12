using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestCamControl : MonoBehaviour {

    public float speedH = 2.0f;
    private float yaw = 0.0f;
    public GameObject player;
    

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        transform.LookAt(player.transform.position);
        transform.eulerAngles = new Vector3(0f, yaw, 0f);

    }
}
