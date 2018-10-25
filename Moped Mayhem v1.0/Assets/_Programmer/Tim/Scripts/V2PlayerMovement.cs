using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2PlayerMovement : MonoBehaviour
{
	public GameObject m_Player, m_FrontWheel, m_RearWheel;
	public WheelCollider m_FrontWheelCol, m_RearWheelCol;
	public float m_fTopSpeed = 250f, m_fMaxTorque = 200f, m_fMaxSteerAngle = 45f, m_fMaxBreakTorque = 2200, m_fCurrentSpeed;
	private float m_fForward, m_fTurn;

	private Rigidbody m_PlayerRB;

	// Use this for initialization
	void Start ()
	{
		m_PlayerRB = m_Player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		m_fForward = Input.GetAxis("Vertical");
		m_fTurn = Input.GetAxis("Horizontal");

		m_FrontWheelCol.steerAngle = m_fMaxSteerAngle * m_fTurn;
		m_fCurrentSpeed = 2 * 22 / 7 * m_RearWheelCol.radius * m_FrontWheelCol.rpm * 60 / 1000;

		if (m_fCurrentSpeed < m_fTopSpeed)
		{
			m_RearWheelCol.motorTorque = m_fMaxTorque * m_fForward;
		}
	}

	private void Update()
	{
		Quaternion m_qFrontWheel;
		Vector3 m_vFrontWheel;
		m_FrontWheelCol.GetWorldPose(out m_vFrontWheel, out m_qFrontWheel);
		m_FrontWheel.transform.position = m_vFrontWheel;
		m_FrontWheel.transform.rotation = m_qFrontWheel;

		Quaternion m_qRearWheel;
		Vector3 m_vRearWheel;
		m_RearWheelCol.GetWorldPose(out m_vRearWheel, out m_qRearWheel);
		m_RearWheel.transform.position = m_vRearWheel;
		m_RearWheel.transform.rotation = m_qRearWheel;
	}
}
