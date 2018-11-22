using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerMovement : EnemyMovement
{
	public float m_fAttackSpeed;

	[Range(0.5f, 1.0f)]
	public float m_fSlowDownPoint = 0.8f;

	private float m_fAttackTime;

	private float m_fAttackEndTime;
	private float m_fStartRange;
	private Vector3 m_StartBikerVelocity;

	public bool BikerAttack()
	{
		m_NavAgent.nextPosition = transform.position;

		Vector3 v3TargetDir = Vector3.Normalize(m_Player.transform.position - transform.position);
		// If the target is roughly in front of the biker
		if (Vector3.Dot(transform.forward, v3TargetDir) > 0.3)
		{
			// IF current speed is lower than attack speed
			if (m_Rigidbody.velocity.magnitude < m_fAttackSpeed)
			{
				// Ramp up Speed by Lerping
				float fCurrentRange = Vector3.Magnitude(m_Player.transform.position - transform.position);

				//Lerp time is range to target
				float fLerpPos = Mathf.Abs((m_fStartRange - fCurrentRange) / m_fStartRange * 2);


				// Lerp Velocity
				Vector3 v3NewVelocity = Vector3.Lerp(m_StartBikerVelocity, transform.forward * m_fAttackSpeed, fLerpPos);

				// IF new speed is greater than max speed
				if (v3NewVelocity.magnitude > m_fAttackSpeed)
				{
					// make new speed equal to max speed
					v3NewVelocity.Normalize();
					v3NewVelocity *= m_fAttackSpeed;
				}

				// Set rigidbody velocity as new velocity
				m_Rigidbody.velocity = v3NewVelocity;
			}
		}

		// Get Current Time
		float fCurrentTime = Time.fixedTime;

		if (fCurrentTime > m_fAttackEndTime)
		{
			// Attack complete
			m_Rigidbody.velocity = Vector3.zero;
			return true;
		}
		else
		{
			float fSlowdownDuration = m_fAttackTime * (1 - m_fSlowDownPoint);
			float fSlowdownTime = m_fAttackEndTime - fSlowdownDuration;

			if (fCurrentTime > fSlowdownTime)
			{
				float fLerpPos = 1- ((fCurrentTime - fSlowdownTime) / fSlowdownDuration);

				Vector3 v3NewVelocity = Vector3.Lerp(m_Rigidbody.velocity, Vector3.zero, fLerpPos);
				m_Rigidbody.velocity = v3NewVelocity;
			}
			
			
		}

		
		var temp2 = Vector3.Normalize(m_Rigidbody.velocity);
		var temp3 = transform.forward;
		var temp4 = Vector3.Dot(temp2, v3TargetDir);

		if (temp4 < 0.3)
		{
			//Debug.LogError("Biker Off Course");
		}

		// Attack incomplete
		return false;
	}

	public void BikerAttackStart(float fAttackTime)
	{
		m_fAttackTime = fAttackTime;    //CB::Might make this dependent on range

		m_fAttackEndTime = Time.fixedTime + fAttackTime;

		// Get Start Range
		m_fStartRange = Vector3.Magnitude(m_Player.transform.position - transform.position);

		Vector3 v3RigidbodyVelocity = m_Rigidbody.velocity;
		Vector3 v3NavAgentVelocity = m_NavAgent.velocity;

		if (v3RigidbodyVelocity.sqrMagnitude > v3NavAgentVelocity.sqrMagnitude)
		{
			m_StartBikerVelocity = v3RigidbodyVelocity;
		}
		else
		{
			m_StartBikerVelocity = v3NavAgentVelocity;
			m_Rigidbody.velocity = v3NavAgentVelocity;
		}

		m_NavAgent.updatePosition = false;
		m_NavAgent.updateRotation = false;

		// Set Rotation
		Vector3 v3Target = m_Player.transform.position;
		transform.LookAt(v3Target);

		// Zero out Angular velocity
		m_Rigidbody.angularVelocity = Vector3.zero;

		// Fix velocity
		Vector3 v3TargetDir = v3Target - transform.position;
		v3TargetDir.Normalize();

		Vector3 v3Velocity = m_Rigidbody.velocity;
		float fMag = v3Velocity.magnitude;
		v3Velocity.Normalize();

		float fDot = Vector3.Dot(v3Velocity, v3TargetDir);
		m_Rigidbody.velocity = v3TargetDir * fDot * fMag;
	}

	public void BikerStop()
	{
		if (m_NavAgent.updatePosition)
		{
			m_NavAgent.updatePosition = false;
			m_NavAgent.updateRotation = false;
		}

		m_NavAgent.nextPosition = transform.position;
	}
}

