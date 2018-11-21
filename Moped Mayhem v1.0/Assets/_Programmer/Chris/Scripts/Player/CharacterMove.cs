using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	private CharacterController m_Controller;
	public Transform m_CenOfMass;

	public float m_fSpeed = 100.0f;
	public float m_fRotSpeed = 10.0f;

	public float m_fGravity = 10.0f;

	// Use this for initialization
	void Start ()
	{
		m_Controller = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float fVer = Input.GetAxis("Vertical");
		float fHor = Input.GetAxis("Horizontal");

		if (Mathf.Abs(fHor) > 0.1f)
		{
			float fAngle = fHor * Time.fixedDeltaTime * m_fRotSpeed;
			transform.RotateAround(m_CenOfMass.position, transform.up, fAngle);
		}

		Vector3 v3Movement = transform.forward * fVer * Time.fixedDeltaTime * m_fSpeed;
		v3Movement.y = -m_fGravity * Time.fixedDeltaTime;		


		m_Controller.Move(v3Movement);
	}
}
