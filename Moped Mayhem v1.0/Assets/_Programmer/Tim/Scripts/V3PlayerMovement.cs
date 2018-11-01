using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V3PlayerMovement : MonoBehaviour {

	public List<AxleInfo> m_AxleInfo;   // list of axles that the bike will have (2 front 2 back)
	[Range(1, 100)]
	public float m_fMaxMotorTorque;     // Motor torque to make the bike move
	public float m_fMaxAngle, f_mMinAngle;   // Steer Angle for turning the car
	public Rigidbody m_PlayerRB;

	float m_fSteer;

	public GameObject m_PlayerCharacterMain;
	public float m_fRotAngle;
	public float m_fMaxTime;

	float timer;

	public void FixedUpdate()
	{
		float motor = m_fMaxMotorTorque * Input.GetAxis("Vertical");

		if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
		{
			timer += Time.fixedDeltaTime;
		} 
		else
		{
			timer = 0;
		}
		float fLerpTime = timer / m_fMaxTime;
		float fLerp = Mathf.Lerp(f_mMinAngle, m_fMaxAngle, fLerpTime);
		/*
		if (Input.GetAxis("Horizontal") > 0)
		{
			m_fSteer = fLerp;
		}
		else
		{
			m_fSteer = -fLerp;
		}
		*/
		m_fSteer = fLerp * Input.GetAxis("Horizontal");

		Drive(motor);
		Turn(m_fSteer);

	}

	public void Drive(float motor)
	{
		foreach (AxleInfo axle in m_AxleInfo)
		{
			if (axle.m_bMotor)
			{
				axle.m_Wheel1.motorTorque = motor;
				axle.m_Wheel2.motorTorque = motor;
			}
		}
	}

	public void Turn(float steer)
	{
		foreach (AxleInfo axle in m_AxleInfo)
		{
			if (axle.m_bSteering)
			{
				axle.m_Wheel1.steerAngle = steer;
				axle.m_Wheel2.steerAngle = steer;
			}
		}
	}

	public void Boost(float speed, float duration, float cooldown)
	{

	}
}
