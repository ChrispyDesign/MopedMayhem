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

	protected override void Setup()
	{
		// Check if ParentFSM isnt BikerAI
		if (m_ParentFSM.GetType() != typeof(BikerAI))
		{
			// Chastise Designers
			Debug.LogError(this.name + " should only be attached to a biker along with BikerAI. Make it so #1");
		}

		m_BikerAI = (BikerAI)m_ParentFSM;
	}

	public override void OnEnd()
	{

	}

	public override void UpdateState()
	{
	}
} 
