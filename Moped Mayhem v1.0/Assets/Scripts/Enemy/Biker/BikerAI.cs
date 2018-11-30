// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 09/11/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerAI : BaseFSM
{
	[Tooltip("Max angle offset from forward, in degrees")]
	[Range(5.0f, 30.0f)]
	public float m_fMaxAttackAngle;
	public float m_fAttackRange;
	public float m_fChaseRange;
	public bool m_bAlwaysChase;
	public GameObject m_Player;

	public DeathScript m_Death;

	protected override void Setup()
	{
		// IF Player has not been set
		if (!m_Player)
		{
			m_Player = GameObject.FindGameObjectWithTag("Player");
		}

		if (!m_Death)
		{
			m_Death = GetComponent<DeathScript>();
		}

		// IF always chase is true
		if (m_bAlwaysChase)
		{
			// Set chase range to max float value
			m_fChaseRange = float.MaxValue;
		}

		// Perform Base Setup
		base.Setup();
	}
}
