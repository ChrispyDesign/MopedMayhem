using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour {

	public GameObject m_SniperHit;
	public GameObject m_Boost;

	public void Play(GameObject particleObject)
	{
		if (particleObject == null)
		{
			Debug.LogWarning("Particle Object is null");
			return;
		}

		var effect = particleObject.GetComponent<ParticleContainer>();
		if (effect != null)
		{
			effect.Play();
		}
	}

	public void Stop(GameObject particleObject)
	{
		if (particleObject == null)
		{
			Debug.LogWarning("Particle Object is null");
			return;
		}

		var effect = particleObject.GetComponent<ParticleContainer>();
		if (effect != null)
		{
			effect.Stop();
		}
	}
}
