// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 02/11/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementSensor : MonoBehaviour {

	public GameObject m_ThisEnemy;
	public Transform m_ReferencePoint;
	public float m_fMaxSeperation;

	public float m_fSeperation;
	public GameObject m_ClosestObject;
	
	public bool m_bColliding = false;

	private void Awake()
	{
		Reset();
	}

	private void Reset()
	{
		m_fSeperation = m_fMaxSeperation;
		m_bColliding = false;
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject == m_ThisEnemy || other.gameObject.tag == "Player")
		{
			return;
		}

		m_bColliding = true;

		Vector3 otherPoint = other.ClosestPoint(m_ReferencePoint.position);
		float fSeperation = Vector3.Magnitude(otherPoint - m_ReferencePoint.position);

		if (fSeperation < m_fSeperation)
		{
			m_fSeperation = fSeperation;
			m_ClosestObject = other.gameObject;
		}
		else if (m_ClosestObject == other.gameObject)
		{
			m_fSeperation = fSeperation;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (m_ClosestObject == other.gameObject)
		{
			Reset();
		}
	}
}
