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
	public EnemyCollision m_EnemyCollision;

	public float m_fAcceleration;
	public float m_fMaxChaseSpeed;
	public float m_fMaxCatchUpSpeed;
	public float m_fMaxTurnSpeed;
	public float m_fMaxBrakingForce;
	public float m_fMaxReverseSpeed;
	public float m_fOptimalTurnSpeed;

	[Range(0, 3f)]
	public float m_fOptimalTurnRadians;

	[Range(0.5f, 1.5f)]
	public float m_fMaxCollisionTurnRadians = 1.5f;

	protected NavMeshAgent m_NavAgent;
	protected Rigidbody m_Rigidbody;

	public bool m_bGetPath = false;
	public bool m_bMoveChase = false;
	public bool m_bMoveCatchUp = false;

	public LineRenderer m_Line;

	public bool m_bReversing = false;

	// Use this for initialization
	protected void Start()
	{
		m_NavAgent = gameObject.GetComponent<NavMeshAgent>();
		m_Rigidbody = gameObject.GetComponent<Rigidbody>();

		// Set Up RigidBody
		m_Rigidbody.maxAngularVelocity = m_fMaxTurnSpeed;
	}

	protected void Update()
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

		/// Calculate Reversing (3 Point Turn)

		// IF Reversing Sensor has collision
		if (m_ReversingSensor.m_bActive)
		{
			// Start Reversing
			m_bReversing = true;
			if (m_RearSensor.m_bColliding)
			{
				m_bReversing = false;
			}
		}
		else if (m_bReversing)
		{
			m_bReversing = false;
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
				Vector3 brakingImpulse = -Vector3.Normalize(m_Rigidbody.velocity) * m_fAcceleration * fDeltaTime;
				if (brakingImpulse.magnitude > m_fMaxBrakingForce)
				{
					brakingImpulse.Normalize();
					brakingImpulse *= m_fMaxBrakingForce;
				}

				if (m_Rigidbody.velocity.sqrMagnitude < brakingImpulse.sqrMagnitude)
				{
					m_Rigidbody.velocity = Vector3.zero;
				}
				else
				{
					m_Rigidbody.velocity -= brakingImpulse;
				}
			}
			// ELSE
			else
			{
				// Reverse
				Vector3 reversingForce = -transform.forward * m_fAcceleration;
				v3Acceleration += reversingForce;
			}

			if (m_RearSensor.m_bColliding)
			{
				m_bReversing = false;
			}

		}

		/// Calculate Path Acceleration
		if (!m_bReversing)
		{
			Vector3 acceleratingImpulse = transform.forward * m_fAcceleration;
			v3Acceleration += acceleratingImpulse;
		}

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

		/// Check velocity is within bounds (Do this before braking)
		if (m_Rigidbody.velocity.magnitude > m_fMaxChaseSpeed)
		{
			m_Rigidbody.velocity = Vector3.Normalize(m_Rigidbody.velocity) * m_fMaxChaseSpeed;
		}

		/// Calculate Path Braking
		Vector3 v3BrakingImpulse = new Vector3();
		// IF not reversing
		if (!m_bReversing)
		{
			
			// Add Path Braking to velocity 
			if (path.corners.Length > 2)
			{
				Vector3 lhs = path.corners[1] - path.corners[0];
				float fDistanceTillTurn = lhs.magnitude;
				lhs.Normalize();
				Vector3 rhs = path.corners[2] - path.corners[1];
				rhs.Normalize();

				float fDot = Vector3.Dot(lhs, rhs);
				float fRad = Mathf.Acos(fDot);

				if (fRad > m_fOptimalTurnRadians)
				{
					Vector3 v3CurrentVelocity = m_Rigidbody.velocity;
					float fCurrentSpeed = v3CurrentVelocity.magnitude;

					if (fCurrentSpeed > m_fOptimalTurnSpeed)
					{
						float fTimeTillTurn = fDistanceTillTurn / fCurrentSpeed;
						float fBrakingMagnitude = (m_fOptimalTurnSpeed - fCurrentSpeed) / fTimeTillTurn;

						if (fBrakingMagnitude > m_fMaxBrakingForce)
						{
							fBrakingMagnitude = m_fMaxBrakingForce;
						}

						v3BrakingImpulse += -Vector3.Normalize(m_Rigidbody.velocity) * fBrakingMagnitude;
					}
				}
			}
		}

		/// Calculate Collision Braking
		// Add Collision Braking to velocity
		if (m_FrontSensor.m_bColliding)
		{
			float fBrakingMultiplier = ((m_FrontSensor.m_fMaxSeperation - m_FrontSensor.m_fSeperation) / m_FrontSensor.m_fMaxSeperation);
			v3BrakingImpulse += -Vector3.Normalize(m_Rigidbody.velocity) * m_fMaxBrakingForce * fBrakingMultiplier;

			if (v3BrakingImpulse.magnitude > m_fMaxBrakingForce)
			{
				v3BrakingImpulse.Normalize();
				v3BrakingImpulse *= m_fMaxBrakingForce;
			}
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

		// MOVE
		m_Rigidbody.AddForce(v3Acceleration, ForceMode.Impulse);
		if (m_Rigidbody.velocity.magnitude > m_fMaxChaseSpeed)
		{
			Debug.Log("Maxxed");
			m_Rigidbody.velocity = Vector3.Normalize(m_Rigidbody.velocity) * m_fMaxChaseSpeed;
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
		

		Debug.Log(m_Rigidbody.angularVelocity);

		// BRAKE
		if (m_Rigidbody.velocity.sqrMagnitude < v3BrakingImpulse.sqrMagnitude)
		{
			m_Rigidbody.velocity = Vector3.zero;
		}
		else
		{
			m_Rigidbody.velocity -= v3BrakingImpulse;
		}
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
