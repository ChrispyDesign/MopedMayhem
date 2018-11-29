// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 01/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerChaseState : BaseState
{
	private BikerAI m_BikerAI;
	private BikerMovement m_Movement;
    public AudioSource m_BikerAudio;

	protected override void Setup()
	{
		// Check if ParentFSM isnt BikerAI
		if (m_ParentFSM.GetType() != typeof(BikerAI))
		{
			// Chastise Designers
			Debug.LogError(this.name + " should only be attached to a biker along with BikerAI. Make it so #1");
		}

		m_BikerAI = (BikerAI)m_ParentFSM;
		m_Movement = GetComponent<BikerMovement>();
        m_BikerAudio.Play();
		m_BikerAI.m_Death.m_bAllowCheckStuck = true;

	}

	public override void OnEnd()
	{
		m_BikerAI.m_Death.m_bAllowCheckStuck = false;
	}

	public override void UpdateState()
	{
		var playerPos = m_BikerAI.m_Player.transform.position;
		float fRange = Vector3.Magnitude(playerPos - transform.position);
		// IF within attack range
		if (fRange < m_BikerAI.m_fAttackRange)
		{
			if (Vector3.Angle(transform.forward, playerPos - transform.position) < m_BikerAI.m_fMaxAttackAngle)
			{
				m_BikerAI.ChangeState("BikerAttackState");
				return;
			}
		}

		// IF beyond chase range
		else if (fRange > m_BikerAI.m_fChaseRange)
		{
			m_BikerAI.ChangeState("BikerCatchupState");
			return;
		}

		m_Movement.GetPathToPlayer();
		m_Movement.MoveChase();
	}
} 
