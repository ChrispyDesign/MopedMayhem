using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

	private Rigidbody parent;

	// Use this for initialization
	void Start ()
	{
		parent = gameObject.GetComponentInParent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		transform.rotation = transform.parent.rotation;
	}

	// Update is called once per frame
	private void OnCollisionStay(Collision collision)
	{
		//CB::HERENOW
		//collision.contacts[0].
	}
}
