// Main Author - Afridi Rahim
// Modified by - Tim Langford
// Date Last worked on 18/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestCamControl : MonoBehaviour
{

    public float speedH = 2.0f; // Speed horizontal
    public float speedV = 2.0f; // Speed Vertical
	public GameObject PivotPoint; // take in the Pivot point
	public GameObject Player; // take in the player
	private Quaternion offset; // offset for the camera

    private float yaw = 0.0f; // yaw to allow the player to rotate

	//------------------------------------------------------
	// Update()
	//		Updates the game function
	//------------------------------------------------------
	void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X"); // get controller and keyboard camera inputs
		
		PivotPoint.transform.eulerAngles = new Vector3(0, yaw, 0); // Changes the camera rotation
		
		offset = Player.transform.rotation * PivotPoint.transform.rotation; // Creates the offset
		PivotPoint.transform.rotation *= offset; // offset the camera relitive to the car
    }
}
