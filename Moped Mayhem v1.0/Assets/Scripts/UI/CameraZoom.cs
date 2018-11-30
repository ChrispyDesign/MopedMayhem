// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 21/11/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

	private Rigidbody m_PlayerRB;
	private Camera m_Camera;

	public float m_fMaxSpeed;
	public float m_fMaxSize;

	private float m_fInitialSize;

	public float m_fDampTime = 1.0f;
	public float m_fMaxDampSpeed = 10.0f;

	private float m_fDampVelocity = 0.0f;


	// Use this for initialization
	void Start ()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		m_PlayerRB = player.GetComponent<Rigidbody>();

		m_Camera = gameObject.GetComponent<Camera>();

		m_fInitialSize = m_Camera.orthographicSize;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float fCurrentSize = m_Camera.orthographicSize;

		float fSpeed = m_PlayerRB.velocity.magnitude;
		if (fSpeed > m_fMaxSpeed)
		{
			fSpeed = m_fMaxSpeed;
		}

		float fLerp = 1 - ((m_fMaxSpeed - fSpeed) / m_fMaxSpeed);

		float fDesiredSize = Mathf.Lerp(m_fInitialSize, m_fMaxSize, fLerp);

		
		float fNewSize = Mathf.SmoothDamp(fCurrentSize, fDesiredSize, ref m_fDampVelocity, m_fDampTime, m_fMaxDampSpeed, Time.deltaTime);
		m_Camera.orthographicSize = fNewSize;
	}
}
