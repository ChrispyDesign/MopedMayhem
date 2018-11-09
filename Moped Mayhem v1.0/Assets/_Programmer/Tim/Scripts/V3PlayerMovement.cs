using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V3PlayerMovement : MonoBehaviour {

	public List<AxleInfo> m_AxleInfo;   // list of axles that the bike will have (2 front 2 back)
	public float m_fMaxMotorTorque;     // Motor torque to make the bike move
	public Rigidbody m_PlayerRB;

	float m_fSteer;
	[Header("Steering")]
	public float m_fSteerMaxTime;
	public float m_fMaxAngle, m_fMinAngle;   // Steer Angle for turning the car

	[Header("Tilting")]
	public GameObject m_PlayerCharacterMain;
	[Range(0,1)]
	public float m_fRotAngle;

	float timer;

	[Header("Boost")]
	public float boostSpeed;
	public float m_fCooldown;
	private  float m_fDuration;
	public float m_fDurationDefault;
	private float fCooldown;
	public float BoostMultiply;
	private float DefaultMass = 5;
	private float DefaultDrag = 0.5f;
	private float DefaultAngularDrag = 4;
	private bool m_bBoosting = false;

	private void Start()
	{
		fCooldown = m_fCooldown;
		m_fDuration = m_fDurationDefault;
	}

	public void FixedUpdate()
	{
		float v = Input.GetAxis("Vertical");
		float motor = m_fMaxMotorTorque * v;
		float m_PlayerRot = Input.GetAxis("Horizontal");

		var PlayerVelocity = Mathf.Abs(Vector3.Dot(m_PlayerRB.transform.forward, Vector3.Normalize(m_PlayerRB.velocity)));
		float curAngle = this.transform.rotation.z;

		if (Mathf.Abs(m_PlayerRot) > 0.1f)
		{
			timer += Time.fixedDeltaTime;
		} 
		else
		{
			timer = 0;
		}
		float fLerpTime = timer / m_fSteerMaxTime;

		float fLerp = Mathf.Lerp(m_fMinAngle, m_fMaxAngle, fLerpTime);
		
		m_fSteer = fLerp * m_PlayerRot;

		if (m_PlayerRot == 0)
		{

			float RotationLerp = Mathf.Lerp(curAngle, 0, 60 * Time.deltaTime);
			m_PlayerCharacterMain.transform.localRotation = new Quaternion(0, 0, -RotationLerp, 1);
		}
		else
		{
			
			float m_CurrentAngle = m_fRotAngle * m_PlayerRot;
			float RotationLerp = Mathf.Lerp(curAngle, m_CurrentAngle, 60 * Time.deltaTime);

			m_PlayerCharacterMain.transform.localRotation = new Quaternion(0, 0, -RotationLerp, 1);
		}

		Drive(motor);
		Turn(m_fSteer);
		Boost(v);
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

	public void Boost(float v)
	{
		float m_fTimer = Time.timeSinceLevelLoad;
		var m_PlayerVelocity = Vector3.Dot(m_PlayerRB.transform.forward, Vector3.Normalize(m_PlayerRB.velocity));

		if (Input.GetAxis("Fire2") > 0 && m_fTimer >= fCooldown)
		{
			m_PlayerRB.AddForce(m_PlayerRB.transform.forward * boostSpeed, ForceMode.Impulse);
			m_PlayerRB.mass = m_PlayerRB.mass * BoostMultiply;
			m_PlayerRB.drag = m_PlayerRB.drag * BoostMultiply;
			m_PlayerRB.angularDrag = m_PlayerRB.angularDrag * BoostMultiply;
			fCooldown = m_fTimer + m_fCooldown;
			m_fDuration = m_fTimer + m_fDurationDefault;
			m_bBoosting = true;
		}

		if (m_fTimer > m_fDuration && m_bBoosting == true)
		{
			m_PlayerRB.mass = DefaultMass;
			m_PlayerRB.drag = DefaultDrag;
			m_PlayerRB.angularDrag = DefaultAngularDrag;
			m_bBoosting = false;
		}
	}
}
