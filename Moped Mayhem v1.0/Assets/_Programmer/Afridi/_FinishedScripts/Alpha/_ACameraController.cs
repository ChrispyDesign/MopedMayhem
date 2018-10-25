// Main Author - Afridi Rahim
// Modified by - Tim Langford
// Date Last worked on 18/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ACameraController : MonoBehaviour
{

    public float fSpeedH = 2.0f; // Speed horizontal
    public float fSpeedV = 2.0f; // Speed Vertical
    public GameObject g_PivotPoint; // take in the Pivot point
    public GameObject g_Player; // take in the player
    private Quaternion q_offset; // offset for the camera

    private float fyaw = 0.0f; // yaw to allow the player to rotate

    //------------------------------------------------------
    // Update()
    //		Updates the game function
    //------------------------------------------------------
    void Update()
    {
        fyaw += fSpeedH * Input.GetAxis("Mouse X"); // get controller and keyboard camera inputs

        g_PivotPoint.transform.eulerAngles = new Vector3(0, fyaw, 0); // Changes the camera rotation

        q_offset = g_Player.transform.rotation * g_PivotPoint.transform.rotation; // Creates the offset
        g_PivotPoint.transform.rotation *= q_offset; // offset the camera relitive to the car
    }
}
