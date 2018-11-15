using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleContainer : MonoBehaviour {

	public bool m_bCanDie = true;

	private float m_fKillTime = 0.0f;

	// Use this for initialization
	void Awake ()
	{
		float fDuration = 0.0f;
		var particleSystems = transform.GetComponentsInChildren<ParticleSystem>();
		foreach (var system in particleSystems)
		{
			// Make sure all particle systems are playing
			if (!system.isPlaying)
			{
				system.Play();
			}

			// Find longest duration
			if (fDuration < system.main.duration)
			{
				fDuration = system.main.duration;
			}
		}

		// Make sure systems are all well and truly finished before killing it
		m_fKillTime = fDuration * 2;

		// Check to see if it can die
		if (m_bCanDie)
		{
			// Schedule it to die
			Destroy(gameObject, m_fKillTime);
		}
	}
}
