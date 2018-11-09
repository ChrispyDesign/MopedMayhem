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
	private GameObject CenOfMass;
	public Rigidbody pRigidBody; // players Rigid Body

	[Range(0, 10)]
	public float m_fBaseAngularDrag;
	[Range(0, 5)]
	public float m_fEXAngularDrag;

	Vector3 m_EularAngleVelocity;

	[Range(0,4)]
	public float m_fDragLerpMin, m_fDragLerpMax;

	[Range(1, 20)]
	public float m_fGravity;


	//------------------------------------------------------
	// Start()
	//		Starting function
	//------------------------------------------------------
	void Start ()
	{
		pRigidBody = player.GetComponent<Rigidbody>();
		fForwardSpeed = fSpeed;

		CenOfMass = GameObject.Find("CenOfMass");

		pRigidBody.centerOfMass = new Vector3(0, 0.5f, -0.5f);
		CenOfMass.transform.position = pRigidBody.centerOfMass;
		CenOfMass.transform.rotation = pRigidBody.rotation;
		Physics.gravity = Vector3.down * m_fGravity;
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
		var PlayerVelocity = Vector3.Dot(CenOfMass.transform.forward, Vector3.Normalize(pRigidBody.velocity));
		//Debug.Log(PlayerVelocity);

		if (PlayerVelocity > 0.01)
		{
			Turn(h);
		}
		else if (PlayerVelocity < -0.01)
		{
			Turn(-h);
		}

		pRigidBody.maxAngularVelocity = 2.5f;

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
		float h = fRotSpeed * horizon;
		m_EularAngleVelocity = new Vector3(0.0f, h, 0.0f);

		pRigidBody.AddTorque(m_EularAngleVelocity, ForceMode.Impulse);

		float m_fLerp = 1 - (pRigidBody.maxAngularVelocity - pRigidBody.angularVelocity.magnitude) / pRigidBody.maxAngularVelocity;
		pRigidBody.drag = Mathf.Lerp(m_fDragLerpMin, m_fDragLerpMax, m_fLerp);

		//pRigidBody.transform.rotation = pRigidBody.rotation * rotation;
		//Quaternion deltaRotation = Quaternion.Euler(m_EularAngleVelocity * Time.deltaTime);
		//pRigidBody.MoveRotation(pRigidBody.rotation * deltaRotation);
	}
}
