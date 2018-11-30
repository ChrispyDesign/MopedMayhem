// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 21/11/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour {

	public ChrisSpawner m_Spawner;

	public bool m_bIsSniper;
	public int m_nSpawnIndex;
	
	void OnDestroy ()
	{
		if (m_bIsSniper)
		{
			m_Spawner.FreeSniperSpawn(m_nSpawnIndex);
			m_Spawner.m_nActiveSnipers--;
		}
		else
		{
			m_Spawner.m_nActiveBikers--;
		}
	}
}
