using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour {

	public GameObject m_SniperHit;
	public GameObject m_Boost;

	[Header("Money")]
	public GameObject m_GainMoney;
	public GameObject m_LoseMoney;

	[Header("Pickup Food")]
	public GameObject m_PickUpBurger;
	public GameObject m_PickUpChinese;
	public GameObject m_PickUpSushi;
	public GameObject m_PickUpDoughnuts;

	[Header("Dropoff Food")]
	public GameObject m_DropoffBurger;
	public GameObject m_DropoffChinese;
	public GameObject m_DropoffSushi;
	public GameObject m_DropoffDoughnuts;

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
