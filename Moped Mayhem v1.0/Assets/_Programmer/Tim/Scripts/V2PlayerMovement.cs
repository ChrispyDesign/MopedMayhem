using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2PlayerMovement : MonoBehaviour
{
	/*
	public GameObject m_Player, m_FrontWheelR, m_RearWheelR;
	public WheelCollider m_FrontWheelColR, m_RearWheelColR;
	public float m_fTopSpeed = 250f, m_fMaxTorque = 200f, m_fMaxSteerAngle = 45f, m_fMaxBreakTorque = 2200, m_fCurrentSpeed;
	private float m_fForward, m_fTurn, m_fBreak;


	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		m_fForward = Input.GetAxis("Vertical");
		m_fTurn = Input.GetAxis("Horizontal");
		m_fBreak = ;

		m_FrontWheelColR.steerAngle = m_fMaxSteerAngle * m_fTurn;
		//m_FrontWheelColL.steerAngle = m_fMaxSteerAngle * m_fTurn;
		m_fCurrentSpeed = 2 * 22 / 7 * m_RearWheelColR.radius * m_RearWheelColR.rpm * 60 / 1000;

		if (m_fCurrentSpeed < m_fTopSpeed)
		{
			m_RearWheelColR.motorTorque = m_fMaxTorque * m_fForward;
			//m_RearWheelColL.motorTorque = m_fMaxTorque * m_fForward;
		}

		m_RearWheelColR.brakeTorque = m_fMaxBreakTorque * m_fBreak;
		m_FrontWheelColR.brakeTorque = m_fMaxBreakTorque * m_fBreak;

		Quaternion m_qFrontWheel = Quaternion.identity;
		Vector3 m_vFrontWheel = Vector3.zero;
		Quaternion m_qRearWheel= Quaternion.identity;
		Vector3 m_vRearWheel = Vector3.zero;
		Debug.Log(m_FrontWheelColR.steerAngle);

		if (m_fForward != 0 && m_fTurn != 0)
		{
			m_FrontWheelColR.GetWorldPose(out m_vFrontWheel, out m_qFrontWheel);
			Debug.Log(m_FrontWheelColR.transform.rotation);
			m_FrontWheelR.transform.position = m_vFrontWheel;
			m_FrontWheelR.transform.rotation = m_qFrontWheel;
			//Debug.Log("FrontWheel Pos" + m_FrontWheelR.transform.position);
			Debug.Log("FrontWheel Rot" + m_FrontWheelR.transform.rotation);
			//this.transform.pos

			m_RearWheelColR.GetWorldPose(out m_vRearWheel, out m_qRearWheel);
			m_RearWheelR.transform.position = m_vRearWheel;
			m_RearWheelR.transform.rotation = m_qRearWheel;
			//Debug.Log("RearWheel Pos" + m_RearWheelR.transform.position);
			//Debug.Log("RearWheel Rot" + m_RearWheelR.transform.rotation);
		}
	}

	private void Update()
	{
	}
	*/

	public List<AxleInfo> m_AxleInfo;
	public float m_fSpeed;
	public float m_fMaxMotorTorque;
	public float m_fMaxSteeringAngle;

	public void FixedUpdate()
	{
		float m_fMotor = m_fMaxMotorTorque * Input.GetAxis("Vertical");
		float m_fSteer = m_fMaxSteeringAngle * Input.GetAxis("Horizontal");

		foreach(AxleInfo axleInfo in m_AxleInfo)
		{
			if(axleInfo.m_bSteering)
			{
				axleInfo.m_Wheel1.steerAngle = m_fSteer;
				axleInfo.m_Wheel2.steerAngle = m_fSteer;
			}
			if (axleInfo.m_bMotor)
			{
				axleInfo.m_Wheel1.motorTorque = m_fMotor * m_fSpeed;
				axleInfo.m_Wheel2.motorTorque = m_fMotor * m_fSpeed;
			}
		}
	}
}

[System.Serializable]
public class AxleInfo
{
	public WheelCollider m_Wheel1;
	public WheelCollider m_Wheel2;
	public bool m_bMotor;
	public bool m_bSteering;
}