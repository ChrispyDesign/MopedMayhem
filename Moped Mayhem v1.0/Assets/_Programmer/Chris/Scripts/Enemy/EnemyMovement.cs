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
		}

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
			// IF going forwards
				// Brake

			// ELSE
				// Reverse
			Vector3 reversingForce = -transform.forward * m_fAcceleration * m_Rigidbody.mass;
			m_Rigidbody.AddForce(reversingForce);

		}

		/// Calculate Path Acceleration
		if (!m_bReversing)
		{
			Vector3 acceleratingForce = transform.forward * m_fAcceleration * m_Rigidbody.mass;
			m_Rigidbody.AddForce(acceleratingForce);
		}

		/// Calculate Path Turning

		/// Calculate Collision Turning

		/// Calculate Path Braking

		/// Calculate Collision Braking
		
	}

	public void MoveCatchUp()
	{
		// If default navigation is NOT enabled
		if (!m_NavAgent.updatePosition)
		{
			// Enable default navigation
			m_NavAgent.updatePosition = true;
			m_NavAgent.updateRotation = true;
		}
	}
}
