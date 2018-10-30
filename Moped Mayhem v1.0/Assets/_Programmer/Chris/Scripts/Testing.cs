using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

	public Rigidbody rb;
	public Transform centerOfMass;

	public Transform forcePos;

	[Range(0.1f, 10f)]
	public float multiplier;

	public bool active;

	// Use this for initialization
	void Start () {
		rb.centerOfMass = centerOfMass.localPosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (active)
		{
			active = false;
			//rb.AddForceAtPosition(transform.forward + transform.right * multiplier, forcePos.position, ForceMode.VelocityChange);
			rb.AddForceAtPosition(transform.forward, forcePos.position, ForceMode.VelocityChange);
			rb.AddForceAtPosition(transform.right * multiplier, forcePos.position, ForceMode.VelocityChange);
			//rb.AddTorque(transform.up * multiplier, ForceMode.VelocityChange);
		}
	}
}
