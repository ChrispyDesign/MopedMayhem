using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerAI : BaseFSM
{
	public float m_fAttackRange;
	public float m_fChaseRange;
	public bool m_bAlwaysChase;
	public GameObject m_Player;

	protected override void Setup()
	{
		// IF Player has not been set
		if (!m_Player)
		{
			// Chastise the designers
			Debug.LogError("Set Player on " + this.name + " Numnutz");
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
