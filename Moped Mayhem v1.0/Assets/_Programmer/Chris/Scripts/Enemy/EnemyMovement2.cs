// Main Author - Christopher Bowles
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
	public EnemyMovementSensor m_LeftSensor;
	public EnemyMovementSensor m_RightSensor;

	public float m_fAcceleration;
	public float m_fReversingAcceleration;
	public float m_fMaxChaseSpeed;
	public float m_fMaxCatchUpSpeed;
	public float m_fMaxTurnSpeed;

	public float m_fOffset = 2.0f;
	public float m_fAccelPathRange = 10.0f;
	public float m_fTurnPathRange = 10.0f;
	
	[Range(0.5f, 1.5f)]
	public float m_fMaxCollisionTurnRadians = 1.5f;

	private NavMeshAgent m_NavAgent;
	private Rigidbody m_Rigidbody;

	public bool m_bGetPath = false;
	public bool m_bMoveChase = false;
	public bool m_bMoveCatchUp = false;

	public LineRenderer m_Line;

	private float m_fLastPathCheck;

	// Use this for initialization
	void Start()
	{
		m_NavAgent = gameObject.GetComponent<NavMeshAgent>();
		m_Rigidbody = gameObject.GetComponent<Rigidbody>();

		// Set Up RigidBody
		m_Rigidbody.maxAngularVelocity = m_fMaxTurnSpeed;
		m_Rigidbody.centerOfMass = m_CenterOfMass.localPosition;
	}

	private void FixedUpdate()
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
		// Get Path depending on range
		float fRange = Vector3.Distance(transform.position, m_Player.transform.position);

		if (fRange > 500)
		{
			if (Time.fixedTime - m_fLastPathCheck > 5.0f)
			{
				m_fLastPathCheck = Time.fixedTime;

				GetPathToPlayer();
			}
		}
		else if (fRange > 100)
		{
			if (Time.fixedTime - m_fLastPathCheck > 2.0f)
			{
				m_fLastPathCheck = Time.fixedTime;

				GetPathToPlayer();
			}
		}
		else
		{
			m_fLastPathCheck = Time.fixedTime;

			GetPathToPlayer();
		}


		float fDeltaTime = Time.deltaTime;
		float fTurnRadians = 0;
		Vector3 v3Acceleration = Vector3.zero;

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

		// For acceleration
		Vector3 accelTarget = path.corners[0];
		float fPathRange = 0.0f;
		int iter = 1;

		while (fPathRange < m_fAccelPathRange)
		{
			if (path.corners.Length > iter)
			{
				accelTarget = path.corners[iter];

				fPathRange = Vector3.Magnitude(accelTarget - path.corners[0]);
			}
			else
			{
				break;
			}

			++iter;
		}

		// For Turning
		Vector3 turnTarget = path.corners[0];
		fPathRange = 0.0f;
		iter = 1;


		while (fPathRange < m_fTurnPathRange)
		{
			if (path.corners.Length > iter)
			{
				turnTarget = path.corners[iter];

				fPathRange = Vector3.Magnitude(turnTarget - path.corners[0]);
			}
			else
			{
				break;
			}

			++iter;
		}

		// Find Rotation

		/// Calculate Path Turning


		//Determine how much it needs to turn
		Vector3 v3PathOffset = accelTarget - path.corners[0];
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

		fTurnRadians *= 4;

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
		float fRatio = Mathf.Abs(Vector3.Dot(m_Rigidbody.velocity, transform.forward));
		fRatio /= m_fMaxChaseSpeed / 2;

		// ROTATE
		if (fTurnRadians > 0.2 || fTurnRadians < -0.2)
		{
			float fTurnSpeed = fTurnRadians * fRatio;

			if (fTurnSpeed > m_fMaxTurnSpeed)
			{
				fTurnSpeed = m_fMaxTurnSpeed;
			}

			if (float.IsNaN(fTurnSpeed))
			{
				Debug.LogWarning("NAN");
			}
			else
			{
				fTurnSpeed *= m_Rigidbody.mass;
				m_Rigidbody.AddTorque(transform.up * fTurnSpeed);
				//m_Rigidbody.AddForceAtPosition(transform.right * fTurnSpeed, m_ForcePos.position);
			}
		}

		// Acceleration

		// Future Pos
		Vector3 futurePos = transform.position + m_Rigidbody.velocity * m_fOffset;
		Vector3 direction = accelTarget - futurePos;

		// Get Path Acceleration 
		v3Acceleration = transform.forward * Vector3.Dot(transform.forward, direction.normalized) * m_fAcceleration;
		//v3Acceleration += transform.forward * 0.25f;
		

		// Check Reversing Sensor
		if (m_ReversingSensor.m_bReversing)
		{
			v3Acceleration = -transform.forward * m_fReversingAcceleration;
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
