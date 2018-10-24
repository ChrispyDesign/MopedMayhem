﻿// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 01/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement2 : MonoBehaviour
{
	public GameObject m_Player;

	public Transform m_CenterOfMass;

	public EnemyReversingSensor m_ReversingSensor;
	public EnemyMovementSensor m_FrontSensor;
	public EnemyMovementSensor m_RearSensor;
	public EnemyMovementSensor m_LeftSensor;
	public EnemyMovementSensor m_RightSensor;

	public float m_fAcceleration;
	public float m_fMaxChaseSpeed;
	public float m_fMaxCatchUpSpeed;
	public float m_fMaxTurnSpeed;
	public float m_fMaxBrakingForce;
	public float m_fMaxReverseSpeed;
	public float m_fOptimalTurnSpeed;

	public float m_fOffset = 2.0f;

	[Range(0, 3f)]
	public float m_fOptimalTurnRadians;

	[Range(0.5f, 1.5f)]
	public float m_fMaxCollisionTurnRadians = 1.5f;

	private NavMeshAgent m_NavAgent;
	private Rigidbody m_Rigidbody;

	public bool m_bGetPath = false;
	public bool m_bMoveChase = false;
	public bool m_bMoveCatchUp = false;

	public LineRenderer m_Line;

	public bool m_bReversing = false;

	// Use this for initialization
	void Start()
	{
		m_NavAgent = gameObject.GetComponent<NavMeshAgent>();
		m_Rigidbody = gameObject.GetComponent<Rigidbody>();

		// Set Up RigidBody
		m_Rigidbody.maxAngularVelocity = m_fMaxTurnSpeed;
		m_Rigidbody.centerOfMass = m_CenterOfMass.position;
	}

	private void Update()
	{
		if (m_bGetPath)
		{
			GetPathToPlayer();
			m_bGetPath = false;
		}

		if (m_bMoveChase && m_bMoveCatchUp)
		{
			m_bMoveChase = false;
			m_bMoveCatchUp = false;
		}

		if (m_bMoveCatchUp)
		{
			MoveCatchUp();
		}

		if (m_bMoveChase)
		{
			MoveChase();
		}

		var path = m_NavAgent.path;
		m_Line.SetPositions(path.corners);
	}

	// Manually Gets Path to Player
	public void GetPathToPlayer()
	{
		m_NavAgent.SetDestination(m_Player.transform.position);
	}

	public void MoveChase()
	{
		float fDeltaTime = Time.deltaTime;
		float fTurnRadians = 0;
		Vector3 v3Acceleration = new Vector3();

		// If default navigation is enabled
		if (m_NavAgent.updatePosition)
		{
			// Disable default navigation
			m_NavAgent.updatePosition = false;
			m_NavAgent.updateRotation = false;

			m_Rigidbody.velocity = m_NavAgent.velocity;
		}

		m_NavAgent.nextPosition = transform.position;
		var path = m_NavAgent.path;


		// Find Rotation

		/// Calculate Path Turning


		//Determine how much it needs to turn
		if (path.corners.Length > 1)
		{
			Vector3 v3PathOffset = path.corners[1] - path.corners[0];
			v3PathOffset.Normalize();

			float fTurnDot = Vector3.Dot(v3PathOffset, transform.forward);
			float fDirectionDot = Vector3.Dot(v3PathOffset, transform.right);

			// IF need to rotate right
			if (fDirectionDot > 0)
			{
				// add rotation amount
				fTurnRadians += Mathf.Acos(fTurnDot);
			}
			// ELSE need to rotate left
			else
			{
				// subtract rotation amount
				fTurnRadians -= Mathf.Acos(fTurnDot);
			}
		}

		/// Calculate Collision Turning
		//Determine how much it needs to turn

		// IF left Sensor is colliding
		if (m_LeftSensor.m_bColliding)
		{
			// Turn more right with less seperation
			float fTurnMultiplier = ((m_LeftSensor.m_fMaxSeperation - m_LeftSensor.m_fSeperation) / m_LeftSensor.m_fMaxSeperation);
			fTurnRadians += m_fMaxCollisionTurnRadians * fTurnMultiplier;
		}

		// IF Right Sensor is colliding
		if (m_RightSensor.m_bColliding)
		{
			// Turn more left with less seperation
			float fTurnMultiplier = ((m_RightSensor.m_fMaxSeperation - m_RightSensor.m_fSeperation) / m_RightSensor.m_fMaxSeperation);
			fTurnRadians -= m_fMaxCollisionTurnRadians * fTurnMultiplier;
		}

		/// Calculate Rotation
		float fRatio;
		float fSpeed = m_Rigidbody.velocity.magnitude;
		if (fSpeed <= m_fOptimalTurnSpeed)
		{
			fRatio = 1 - ((m_fOptimalTurnSpeed - fSpeed) / m_fOptimalTurnSpeed);
		}
		else
		{
			float fOverOptimalSpeed = fSpeed - m_fOptimalTurnSpeed;
			float fMaxOptimalDiff = m_fMaxChaseSpeed - m_fOptimalTurnSpeed;
			fRatio = (fMaxOptimalDiff - fOverOptimalSpeed) / fMaxOptimalDiff;
		}

		// ROTATE
		//if (fTurnRadians > 0.25|| fTurnRadians < -0.25 )
		{
			float fTurnSpeed = fTurnRadians * fRatio;
			if (float.IsNaN(fTurnSpeed))
			{
				Debug.Log("NAN");
			}
			else
			{
				m_Rigidbody.AddTorque(transform.up * fTurnSpeed);
			}
		}

		// Acceleration

		// Future Pos
		if (path.corners.Length > 1)
		{
			Vector3 target = path.corners[1];
			Vector3 futurePos = transform.position + m_Rigidbody.velocity * m_fOffset;
			Vector3 direction = target - futurePos;
			v3Acceleration = transform.forward * Vector3.Dot(transform.forward, direction.normalized) * m_fAcceleration;
		}


		m_Rigidbody.AddForce(v3Acceleration, ForceMode.Impulse);
	}

	public void MoveCatchUp()
	{
		// If default navigation is NOT enabled
		if (!m_NavAgent.updatePosition)
		{
			// Enable default navigation
			m_NavAgent.updatePosition = true;
			m_NavAgent.updateRotation = true;

			m_NavAgent.velocity = m_Rigidbody.velocity;

			// Reset Rigidbody velocity and rotation
			m_Rigidbody.velocity = Vector3.zero;
			m_Rigidbody.rotation = Quaternion.identity;
		}
	}
}
