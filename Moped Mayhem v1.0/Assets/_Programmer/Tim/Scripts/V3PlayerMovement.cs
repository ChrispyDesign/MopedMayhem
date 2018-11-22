using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V3PlayerMovement : MonoBehaviour {

	public List<AxleInfo> m_AxleInfo;   // list of axles that the bike will have (2 front 2 back)
	public float m_fMaxMotorTorque;     // Motor torque to make the bike move
	public Rigidbody m_PlayerRB;

	private PlayerParticles m_PlayerParticles;

	float m_fSteer;
	[Header("Steering")]
	public float m_fSteerMaxTime;
	public float m_fMaxAngle, m_fMinAngle;   // Steer Angle for turning the car

	[Header("Tilting")]
	public GameObject m_PlayerCharacterMain; // input for the players model so that the player rotates
	[Range(0,1)]
	public float m_fRotAngle; // how far the player turns

	float timer;
    public AudioSource PlayerIdle;
    public AudioSource PlayerMove;
    public AudioSource PlayerBoost;

    [Header("Boost")]
	public float boostSpeed; // how much force is added to the boost
	public float m_fCooldown; // Boost cooldown so that it cant be spammed
	private  float m_fDuration;	// how long the boost will go for
	public float m_fDurationDefault;
	private float fCooldown;
	public float BoostMultiply; // multiplying mass drag and angluar drag
	private float DefaultMass = 5; // default mass
	private float DefaultDrag = 0.5f; // default drag
	private float DefaultAngularDrag = 4; // default angular drag
	private bool m_bBoosting = false; // is player boosting

	public float m_fRot = 0.0f;
	public bool m_bAccel = false;

	private void Start()
	{
		fCooldown = m_fCooldown;
		m_fDuration = m_fDurationDefault;

		m_PlayerParticles = GetComponent<PlayerParticles>();
	}

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
		if (Input.GetButtonDown("DEBUG"))
		{
			m_bAccel = !m_bAccel;
		}

		float v = Input.GetAxis("Vertical");
		float fMotor = m_fMaxMotorTorque * v;
		float fPlayerRot = Input.GetAxis("Horizontal");

		m_fRot = fPlayerRot;

		var PlayerVelocity = Mathf.Abs(Vector3.Dot(m_PlayerRB.transform.forward, Vector3.Normalize(m_PlayerRB.velocity)));
		float curAngle = this.transform.rotation.z;

		if (Mathf.Abs(fPlayerRot) > 0.1f)
		{
			timer += Time.fixedDeltaTime;
		} 
		else
		{
			timer = 0;
		}
		float fLerpTime = timer / m_fSteerMaxTime;

		float fLerp = Mathf.Lerp(m_fMinAngle, m_fMaxAngle, fLerpTime);

		fLerp = m_fMaxAngle;
		m_fSteer = fLerp * fPlayerRot;

		//TEST
		m_fSteer = m_fMaxAngle * fPlayerRot;

		//if (m_PlayerRot == 0)
		//{
		//	float RotationLerp = Mathf.Lerp(curAngle, 0, 60 * Time.deltaTime);
		//	m_PlayerCharacterMain.transform.localRotation = new Quaternion(0, 0, -RotationLerp, 1);
		//}
		//else
		//{
		//	float m_CurrentAngle = m_fRotAngle * m_PlayerRot;
		//	float RotationLerp = Mathf.Lerp(curAngle, m_CurrentAngle, 60 * Time.deltaTime);
		//
		//	m_PlayerCharacterMain.transform.localRotation = new Quaternion(0, 0, -RotationLerp, 1);
		//}

		Drive(fMotor);
		Turn(m_fSteer);
		Boost(v);
	}

	public void Drive(float motor)
	{
		// for each Axis if motor bool = true, add torque to wheels
		foreach (AxleInfo axle in m_AxleInfo)
		{
			if (axle.m_bMotor)
			{
				axle.m_Wheel1.motorTorque = motor;
				axle.m_Wheel2.motorTorque = motor;
			}
		}

		motor /= m_fMaxMotorTorque;

        if (m_bAccel)
            if (m_PlayerRB.velocity.magnitude < 2.0f)
            {
                m_PlayerRB.velocity += transform.forward * motor * Time.fixedDeltaTime * 500.0f;
                //PlayerMove.Play();
                Debug.Log("SPEED");
            }
            else {
                //PlayerIdle.Play();
            }
	}

	public void Turn(float steer)
	{
		// for each Axis if steering bool = true, add steer to wheels
		foreach (AxleInfo axle in m_AxleInfo)
		{
			if (axle.m_bSteering)
			{
				axle.m_Wheel1.steerAngle = steer;
				axle.m_Wheel2.steerAngle = steer;
			}
		}
	}

	//------------------------------------------------------
	// Boost()
	//		Boost function
	//
	// var 
	//		float fTimer = timesincelevelload
	//------------------------------------------------------

	public void Boost(float v)
	{
		float m_fTimer = Time.fixedTime + m_fCooldown;
		var m_PlayerVelocity = Vector3.Dot(m_PlayerRB.transform.forward, Vector3.Normalize(m_PlayerRB.velocity));

		// if button clicked and cooldown, add boost for duration
		if (Input.GetAxis("Fire2") > 0 && m_fTimer >= fCooldown) 
		{
			m_PlayerRB.AddForce(m_PlayerRB.transform.forward * boostSpeed, ForceMode.Impulse);
			m_PlayerRB.mass = m_PlayerRB.mass * BoostMultiply;
			m_PlayerRB.drag = m_PlayerRB.drag * BoostMultiply;
			m_PlayerRB.angularDrag = m_PlayerRB.angularDrag * BoostMultiply;
			fCooldown = m_fTimer + m_fCooldown;
			m_fDuration = m_fTimer + m_fDurationDefault;
			m_bBoosting = true;

            // Boost Effect

            //PlayerBoost.Play();
			if (m_PlayerParticles != null)
			{
				m_PlayerParticles.Play(m_PlayerParticles.m_Boost);
			}
            
		}

		// if boosting = true and timer is higher then duration, then return mass drag and angular drag to default values
		if (m_fTimer > m_fDuration && m_bBoosting == true) 
		{
			m_PlayerRB.mass = DefaultMass;
			m_PlayerRB.drag = DefaultDrag;
			m_PlayerRB.angularDrag = DefaultAngularDrag;
			m_bBoosting = false;
		}
	}
}
