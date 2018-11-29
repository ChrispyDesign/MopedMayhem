using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydrant : MonoBehaviour {

	public ParticleContainer HydrantParticles;
	public AudioSource m_WaterSound;
	private bool m_bHit = false;

	private void Awake()
	{
		transform.DetachChildren();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!m_bHit)
		{
			var tag = collision.collider.tag;
			if (tag == "Player" || tag == "Biker" || tag == "Prop")
			{
				if(m_WaterSound)
				{
					m_WaterSound.Play();
				}
				HydrantParticles.Play();
				HydrantParticles.m_bCanDie = true;
				m_bHit = true;
			}
		}
	}
}
