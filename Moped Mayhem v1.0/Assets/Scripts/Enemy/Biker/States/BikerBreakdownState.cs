// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 30/11/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerBreakdownState : BaseState
{
	public float m_fBreakdownTime;
	private float m_fBreakdownEndTime;
	public GameObject[] m_BreakdownParticlePrefabs;
    public BikerChaseState m_StopAudio;

	protected override void Setup()
	{
		foreach (GameObject prefab in m_BreakdownParticlePrefabs)
		{
			Instantiate(prefab, transform.position, prefab.transform.rotation);
			Debug.Log("Starting");
		}

        m_StopAudio.m_BikerAudio.Stop();
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
