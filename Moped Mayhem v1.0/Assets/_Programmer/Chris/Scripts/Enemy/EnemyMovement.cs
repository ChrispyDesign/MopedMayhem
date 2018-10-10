// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 01/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
	public GameObject m_Player;

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

	private NavMeshAgent m_NavAgent;
	private Rigidbody m_Rigidbody;

	public bool m_bGetPath = false;
	public bool m_bMoveChase = false;
	public bool m_bMoveCatchUp = false;

	public LineRenderer m_Line;

	private bool m_bReversing = false;

	// Use this for initialization
	void Start()
	{
		m_NavAgent = gameObject.GetComponent<NavMeshAgent>();
		m_Rigidbody = gameObject.GetComponent<Rigidbody>();
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

		/// Calculate Reversing (3 Point Turn)

		// IF Reversing Sensor has collision
		if (m_ReversingSensor.m_bActive)
		{
			// Start Reversing
			m_bReversing = true;
		}

		// IF Reversing
		if (m_bReversing)
		{
			// Get Dot Product
			Vector2 v2ReversingLhs = new Vector2(m_Rigidbody.velocity.x, m_Rigidbody.velocity.z);
			v2ReversingLhs.Normalize();

			Vector2 v2ReversingRhs = new Vector2(transform.forward.x, transform.forward.z);

			float fDot = Vector2.Dot(v2ReversingLhs, v2ReversingRhs);

			// IF going forwards
			if (fDot > 0.1f)
			{
				// Brake
				Vector3 brakingImpulse = -transform.forward * m_fAcceleration;
				if (brakingImpulse.magnitude > m_fMaxBrakingForce)
				{
					brakingImpulse.Normalize();
					brakingImpulse *= m_fMaxBrakingForce;
				}
				m_Rigidbody.AddForce(brakingImpulse, ForceMode.Impulse);
			}
			// ELSE
			else
			{
				// Reverse
				Vector3 reversingForce = -transform.forward * m_fAcceleration;
				m_Rigidbody.AddForce(reversingForce, ForceMode.Impulse);				
			}

		}

		/// Calculate Path Acceleration
		if (!m_bReversing)
		{
			Vector3 acceleratingImpulse = transform.forward * m_fAcceleration;
			m_Rigidbody.AddForce(acceleratingImpulse, ForceMode.Impulse);
		}

		/// Calculate Path Turning
		float fTurnRadians = 0;

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
		if (m_LeftSensor.m_bColliding)
		{
			float fTurnMultiplier = ((m_LeftSensor.m_fMaxSeperation - m_LeftSensor.m_fSeperation) / m_LeftSensor.m_fMaxSeperation);
			//CB::HERENOW
		}

		/// Calculate Path Braking
		// Add Path Braking to velocity 

		/// Calculate Collision Braking
		// Add Collision Braking to velocity

		/// Check velocity is within bounds

		/// Calculate Rotation
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
