using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotType
{
	NoRot = 0,
	OnSpot,
	SmallFwd,

	Total
}

public class CharacterMove : MonoBehaviour
{
	private DashUI m_DashUI;
	private PlayerParticles m_PlayerParticles;
	private Rigidbody m_PlayerRB;
	public Transform m_CenOfMass;

	[Header("Acceleration")]
	public float m_fAccel;
	public float m_fMaxSpeed = 100.0f;

	[Header("Boost")]
	public float m_fBoostAccel;
	public float m_fBoostMaxSpeed;
	public float m_fBoostDuration;
	public float m_fBoostCooldown;

	private float m_fBoostEndTime;
	private bool m_bDashStarted;

	[Header("Turning")]
	public float m_fMaxTurnRate;
	public float m_fMinTurnRate;
	public float m_fMaxTurnSpeed;
	public float m_fMinTurnSpeed;

	public float m_fStopRot;

	[Tooltip("Turning on the spot")]
	public RotType m_eRotType;

	// Use this for initialization
	void Start()
	{
		m_DashUI = gameObject.GetComponent<DashUI>();
		m_PlayerParticles = gameObject.GetComponent<PlayerParticles>();
		m_PlayerRB = gameObject.GetComponent<Rigidbody>();

		m_PlayerRB.centerOfMass = m_CenOfMass.localPosition;

		m_fBoostEndTime = Time.fixedTime - m_fBoostCooldown;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		float fCurrentTime = Time.fixedTime;
		float fDeltaTime = Time.fixedDeltaTime;

		float fVer = Input.GetAxis("Vertical");
		float fHor = Input.GetAxis("Horizontal");

		// Fast Accel
		Vector3 v3Impulse = transform.forward * m_fAccel * fDeltaTime * fVer;

		Vector3 v3NewVelocity = m_PlayerRB.velocity += v3Impulse;

		float fMaxSpeed = m_fMaxSpeed;

		// Dash

		// IF Can dash
		if (fCurrentTime > m_fBoostEndTime + m_fBoostCooldown)
		{
			if (!m_bDashStarted)
			{
				if (Input.GetButton("Fire2"))
				{
					m_PlayerParticles.Play(m_PlayerParticles.m_Boost);

					m_bDashStarted = true;
					m_fBoostEndTime = fCurrentTime + m_fBoostDuration;

					v3NewVelocity += transform.forward * m_fBoostAccel * fDeltaTime * 60;

                    m_DashUI.StartCharge(m_fBoostCooldown + m_fBoostDuration);
                }
            }
		}

		// IF Dashing
		if (m_bDashStarted)
		{
			fMaxSpeed = m_fBoostMaxSpeed;

			v3NewVelocity += transform.forward * m_fBoostAccel * fDeltaTime * 60;

			if (fCurrentTime > m_fBoostEndTime)
			{
				m_bDashStarted = false;
				//m_DashUI.StartCharge(m_fBoostCooldown);
			}
		}



		// IF Turning
		if (Mathf.Abs(fHor) > 0.1f)
		{
			// Quick Turn
			float fDot = Vector3.Dot(transform.forward, v3NewVelocity.normalized);
			float fMag = v3NewVelocity.magnitude;

			float fTurnRate = 0.0f;

			if (fMag < m_fMaxTurnSpeed)
			{
				fTurnRate = m_fMaxTurnRate;
			}
			else if (fMag > m_fMinTurnSpeed)
			{
				fTurnRate = m_fMinTurnRate;
			}
			else
			{
				float fLerp = (fMag - m_fMaxTurnSpeed) / (m_fMinTurnSpeed - m_fMaxTurnSpeed);
				fTurnRate = Mathf.Lerp(m_fMaxTurnRate, m_fMinTurnRate, fLerp);
			}

			float fSign = fDot / Mathf.Abs(fDot);

			float fRot = fTurnRate * fDeltaTime * fHor * fSign;

			if (!float.IsNaN(fRot))
			{
				Vector3 v3Angular = m_PlayerRB.angularVelocity;
				v3Angular.y += fRot;
				m_PlayerRB.angularVelocity = v3Angular;
			}
			// Stop Turn		

			if (fVer >= 0)
			{
				if (fMag < m_fMaxSpeed * 0.2f)
				{
					float fStopRot = 0.0f;

					// Turn On Spot
					if (m_eRotType == RotType.OnSpot)
					{
						fStopRot = m_fStopRot * fDeltaTime * fHor;
					}

					// Small fwd movement
					if (m_eRotType == RotType.SmallFwd)
					{
						fStopRot = m_fStopRot * fDeltaTime * fHor;

						v3NewVelocity += transform.forward * m_fAccel * fDeltaTime;
					}

					if (!float.IsNaN(fStopRot))
					{
						transform.Rotate(transform.up, fStopRot);
						//transform.RotateAround(m_CenOfMass.position, transform.up, fStopRot);

						Vector3 v3Angular = m_PlayerRB.angularVelocity;
						v3Angular.y += fStopRot;
						m_PlayerRB.angularVelocity = v3Angular;
					}
				}
			}


		}

		float fNewDot = Vector3.Dot(transform.forward, v3NewVelocity.normalized);
		float fNewMag = v3NewVelocity.magnitude;

		Vector3 v3Fwd = transform.forward * fNewMag * fNewDot;

		Vector3 v3Side = v3NewVelocity - v3Fwd;

		v3NewVelocity = v3Fwd + (v3Side * (1 - 2 * fDeltaTime));

		// Apply Movement
		if (v3NewVelocity.magnitude > fMaxSpeed)
		{
			v3NewVelocity = v3NewVelocity.normalized * m_fMaxSpeed;
		}

		m_PlayerRB.velocity = v3NewVelocity;
	}
}
