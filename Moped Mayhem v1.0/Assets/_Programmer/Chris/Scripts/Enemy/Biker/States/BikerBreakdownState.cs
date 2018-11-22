// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 01/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerBreakdownState : BaseState
{
	public float m_fBreakdownTime;
	private float m_fBreakdownEndTime;

	protected override void Setup()
	{
		m_fBreakdownEndTime = Time.fixedTime + m_fBreakdownTime;		
	}

	public override void OnEnd()
	{

	}

	public override void UpdateState()
	{
		// Get Current time
		float fCurrentTime = Time.fixedTime;

		// If Current Time is after Breakdown has ended
		if (fCurrentTime > m_fBreakdownEndTime)
		{
			// Return to chasing
			m_ParentFSM.ChangeState("BikerChaseState");
			return;
		}
		// ELSE Breakdown ongoing 
		else
		{
			//CB::DOSTUFF
		}
	}
}
