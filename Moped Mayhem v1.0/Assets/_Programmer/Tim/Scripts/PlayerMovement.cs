using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[Range(0,1000)]
	public float fSpeed; // move speed
	[Range(0, 1000)]
	public float fReverseSpeed; // move speed
	[Range(0,100)]
	public float fRotSpeed; // rotation speed

	private float fSpeedMultiplier = 100.0f;
	private float fRotMultiplier = 10.0f;

	public GameObject player;
	public Rigidbody pRigidBody;

	// Use this for initialization
	void Start () {
		
		pRigidBody = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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

	public void Move(float vertical)
	{
		Vector3 movement;
		if (vertical > 0)
		{
			movement = fSpeed * vertical * Time.deltaTime * player.transform.forward * fSpeedMultiplier;
		}
		else
		{
			movement = fReverseSpeed * vertical * Time.deltaTime * player.transform.forward * fSpeedMultiplier;
		}
		
		pRigidBody.velocity = movement;
	}

	public void Turn(float horizon)
	{
		float h = horizon * fRotSpeed * Time.deltaTime * fRotMultiplier;
		Quaternion rotation = Quaternion.Euler(0.0f, h, 0.0f);
		pRigidBody.transform.rotation = pRigidBody.rotation * rotation;
	}
}
