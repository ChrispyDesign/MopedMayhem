using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	private CharacterController m_Controller;

	public float m_fSpeed = 10000.0f;
	public float m_fRotSpeed = 1000.0f;

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

		m_Controller.Move(transform.forward * fVer * Time.fixedDeltaTime * m_fSpeed);

		if (Mathf.Abs(fHor) > 0.1f)
		{
			transform.Rotate(transform.up * fHor * Time.fixedDeltaTime * m_fRotSpeed);
		}
	}
}
