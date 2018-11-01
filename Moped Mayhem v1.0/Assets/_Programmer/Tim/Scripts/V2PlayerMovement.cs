// Created by Tim Langford
//
// Date 31/10/2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// --------Things to do----------
/// - Tweek movement
/// - Add Dash
/// </summary>


public class V2PlayerMovement : MonoBehaviour
{
	public List<AxleInfo> m_AxleInfo;	// list of axles that the bike will have (2 front 2 back)
	[Range(1,100)]
	public float m_fSpeed;				// this is a speed multiplier
	public float m_fMaxMotorTorque;		// Motor torque to make the bike move
	public float m_fMaxSteeringAngle;   // Steer Angle for turning the car
	public Rigidbody m_PlayerRB;
	public float m_fBoostCoolDown = 3;
	private float m_fCooldown;

	float m_fSteer;

	public GameObject m_PlayerCharacterMain;
	public float rotAngle; 

	//------------------------------------------------------
	// FixedUpdate()
	//		FixedUpdate function
	//
	// var 
	//		float fMotor = Max motor torque + Verticle Axis
	//		float fSteer = Max steer angle + Horizontal Axis
	//------------------------------------------------------
	public void FixedUpdate()
	{
		float m_fMotor = m_fMaxMotorTorque * Input.GetAxis("Vertical");
		float m_PlayerRot = Input.GetAxis("Horizontal");

		var PlayerVelocity = Mathf.Abs(Vector3.Dot(m_PlayerRB.transform.forward, Vector3.Normalize(m_PlayerRB.velocity)));
		float curAngle = this.transform.rotation.z;

		if (m_fMotor == 0)
		{
			m_fSteer = 0;
			float RotationLerp = Mathf.Lerp(curAngle, 0, 60 * Time.deltaTime);
			m_PlayerCharacterMain.transform.localRotation = new Quaternion(0, 0, -RotationLerp, 1);
		}
		else
		{
			m_fSteer = m_fMaxSteeringAngle * m_PlayerRot;
			float m_CurrentAngle = rotAngle * m_PlayerRot;
			float RotationLerp = Mathf.Lerp(curAngle, m_CurrentAngle, 60 * Time.deltaTime);

			m_PlayerCharacterMain.transform.localRotation = new Quaternion(0, 0, -RotationLerp, 1);
			if(m_PlayerRot > 0.1)
			{
				if (curAngle < -0.1)
				{
					RotationLerp = Mathf.Lerp(curAngle, 0, 60 * Time.deltaTime);
					m_PlayerCharacterMain.transform.localRotation = new Quaternion(0, 0, -RotationLerp, 1);
				}
			}
			if (m_PlayerRot < -0.1)
			{
				if (curAngle > 0.1)
				{
					RotationLerp = Mathf.Lerp(curAngle, 0, 60 * Time.deltaTime);
					m_PlayerCharacterMain.transform.localRotation = new Quaternion(0, 0, -RotationLerp, 1);
				}
			}
		}

		//for each Axis if steer bool is true, add steer and if motor bool = true, add torque to wheels
		foreach(AxleInfo axleInfo in m_AxleInfo)
		{
			if(axleInfo.m_bSteering)
			{
				axleInfo.m_Wheel1.steerAngle = m_fSteer;
				axleInfo.m_Wheel2.steerAngle = m_fSteer;
			}
			if (axleInfo.m_bMotor)
			{
				axleInfo.m_Wheel1.motorTorque = m_fMotor;
				axleInfo.m_Wheel2.motorTorque = m_fMotor;
			}
		}

		if(Input.GetAxis("Horizontal") == 0)
		{
			foreach (AxleInfo axisInfo in m_AxleInfo)
			{
				if(axisInfo.m_bSteering)
				{
					axisInfo.m_Wheel1.steerAngle = 0;
					axisInfo.m_Wheel2.steerAngle = 0;
				}
			}
		}
		
		Dash(m_fSpeed);
	}
	

	//------------------------------------------------------
	// Dash()
	//		Takes in speed to boost player
	//
	//	float timer = time since level loaded
	//	float cooldown = cooldown timer + timer
	//
	//------------------------------------------------------
	public void Dash(float BoostSpeed)
	{
		float m_fTimer = Time.timeSinceLevelLoad;
		var PlayerVelocity = Vector3.Dot(m_PlayerRB.transform.forward, Vector3.Normalize(m_PlayerRB.velocity));
		if (Input.GetAxis("Fire2") > 0 && m_fTimer >= m_fCooldown && PlayerVelocity > 0)
		{
			m_PlayerRB.AddForce(m_PlayerRB.transform.forward * BoostSpeed, ForceMode.Impulse);
			m_fCooldown = m_fTimer + m_fBoostCoolDown;
		}
	}
}

// Axle info for the wheels

[System.Serializable]
public class AxleInfo
{
	public WheelCollider m_Wheel1;
	public WheelCollider m_Wheel2;
	public bool m_bMotor;
	public bool m_bSteering;
}