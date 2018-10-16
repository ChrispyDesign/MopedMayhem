// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 01/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerAttackState : BaseState
{
	private BikerAI m_BikerAI;
	private BikerMovement m_Movement;

	public float m_fAttackTime;

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

		m_Movement.BikerAttackStart(m_fAttackTime);
	}

	public override void OnEnd()
	{

	}

	public override void UpdateState()
	{
		bool bAttackEnded = m_Movement.BikerAttack();

		if (bAttackEnded)
		{
			m_BikerAI.ChangeState("BikerBreakdownState");
		}
	}
}
