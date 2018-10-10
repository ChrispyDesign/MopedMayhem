// Main Author - Tim Langford
//
// Date last worked on 10/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[Range(0,200)]
	public float fSpeed; // move speed
	[Range(0, 100)]
	public float fReverseSpeed; // reverse speed
	private float fForwardSpeed; // forward speed
	[Range(0,100)]
	public float fRotSpeed; // rotation speed
	
	private float fRotMultiplier = 10.0f; // rotation multiplyer

	public GameObject player; // players gameobject
	public Rigidbody pRigidBody; // players Rigid Body

	//------------------------------------------------------
	// Start()
	//		Starting function
	//------------------------------------------------------
	void Start ()
	{
		pRigidBody = player.GetComponent<Rigidbody>();
		fForwardSpeed = fSpeed;
	}

	//------------------------------------------------------
	//	FixedUpdate()
	//		Updates in fixed intervals
	//
	//	var
	//		float v 
	//			Vertical Input
	//		float h 
	//			Horizontal Input
	//------------------------------------------------------
	void FixedUpdate()
	{
		float v = Input.GetAxis("Vertical");
		float h = Input.GetAxis("Horizontal");

		Move(v);

		if (v > 0.1)
			Turn(h);
		else if (v < -0.1)
			Turn(-h);
	}

	//------------------------------------------------------
	// Move
	//		Moves the player forwards and backwards
	//	
	//	var
	//		float vertical
	//			takes in the player input on the vertical axis
	//------------------------------------------------------
	public void Move(float vertical)
	{
		if(vertical > 0.1)
		{
			fSpeed = fForwardSpeed;
		}
		else
		{
			fSpeed = fReverseSpeed;
		}
		pRigidBody.AddForce(player.transform.forward * vertical * fSpeed);
	}

	//------------------------------------------------------
	// Turn(float horizontal)
	//		Turns the player
	//
	//	var
	//		float h
	//			used for the rotation on the y axis
	//
	//		Quaternion rotation
	//			takes in h for rotation
	//------------------------------------------------------
	public void Turn(float horizon)
	{
		float h = horizon * fRotSpeed * Time.deltaTime * fRotMultiplier;
		Quaternion rotation = Quaternion.Euler(0.0f, h, 0.0f);
		pRigidBody.transform.rotation = pRigidBody.rotation * rotation;
	}
}
