// Main Author - Tim Langford
//
// Date last worked on 18/10/18

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

	[Range(0, 10)]
	public float m_fBaseAngularDrag;
	[Range(0, 10)]
	public float m_fEXAngularDrag;

	Vector3 m_EularAngleVelocity;


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
	//		Vector3 rotation
	//			eularAngles rotation
	//------------------------------------------------------
	void FixedUpdate()
	{

		float v = Input.GetAxis("Vertical");
		float h = Input.GetAxis("Horizontal");

		Move(v);
		var PlayerVelocity = Vector3.Dot(player.transform.forward, Vector3.Normalize(pRigidBody.velocity));

		//float fSpeed = pRigidBody.velocity.magnitude;
		//if (fSpeed > 0.1)
		//{
		//	pRigidBody.angularDrag = m_fBaseAngularDrag + (pRigidBody.velocity.magnitude / pRigidBody.maxAngularVelocity) + m_fEXAngularDrag;
		//}
		//else
		//{
		//	pRigidBody.angularDrag = pRigidBody.maxAngularVelocity;
		//}
		
		if (v > 0.1 && PlayerVelocity > 0)
			Turn(h);
		else if (v < -0.1 && PlayerVelocity < 0)
			Turn(-h);

		Vector3 rotation = pRigidBody.rotation.eulerAngles;
		rotation.x = 0;
		rotation.z = 0;

		pRigidBody.rotation = Quaternion.Euler(rotation);
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
	//		pRB.AddTorque
	//			takes in Up , h with forcemode being VelocityChange
	//------------------------------------------------------
	public void Turn(float horizon)
	{
		float h = fRotSpeed * horizon * fRotMultiplier;
		m_EularAngleVelocity = new Vector3(0.0f, h, 0.0f);
		//pRigidBody.transform.rotation = pRigidBody.rotation * rotation;
		Quaternion deltaRotation = Quaternion.Euler(m_EularAngleVelocity * Time.deltaTime);
		pRigidBody.MoveRotation(pRigidBody.rotation * deltaRotation);
	}
}
