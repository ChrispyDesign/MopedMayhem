using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReversingSensor : MonoBehaviour {

	public int m_nBuildingLayer = 8;
	public Transform m_LeftSensor;
	public Transform m_MidSensor;
	public Transform m_RightSensor;

	public float m_fDetectionRange;
	public float m_fReverseRange;

	public bool m_bReversing = false;

	private bool m_bCollided = false;
	private bool m_bEnabled = false;

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == m_nBuildingLayer)
		{
			m_bEnabled = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == m_nBuildingLayer)
		{
			m_bEnabled = false;
		}
	}

	private void FixedUpdate()
	{
		// YAY a bitmask
		int nLayerMask = 1 << m_nBuildingLayer;

		int nRayHits = 0;

		RaycastHit leftHit;
		RaycastHit midHit;
		RaycastHit rightHit;

		Ray leftRay = new Ray(m_LeftSensor.position, transform.forward);
		Ray midRay = new Ray(m_MidSensor.position, transform.forward);
		Ray rightRay = new Ray(m_RightSensor.position, transform.forward);
					
		if (m_bCollided)
		{
			if (Physics.Raycast(leftRay, out leftHit, m_fReverseRange, nLayerMask))
			{
					nRayHits++;
			}

			if (Physics.Raycast(midRay, out midHit, m_fReverseRange, nLayerMask))
			{
					nRayHits++;
			}

			if (Physics.Raycast(rightRay, out rightHit, m_fReverseRange, nLayerMask))
			{
					nRayHits++;
			}

			if (nRayHits < 3)
			{
				m_bCollided = false;
			}

			m_bReversing = true;
			return;
		}

		else if (m_bEnabled)
		{
			if (Physics.Raycast(leftRay, out leftHit, m_fDetectionRange, nLayerMask))
			{
					nRayHits++;
			}

			if (Physics.Raycast(midRay, out midHit, m_fDetectionRange, nLayerMask))
			{
					nRayHits++;
			}

			if (Physics.Raycast(rightRay, out rightHit, m_fDetectionRange, nLayerMask))
			{
					nRayHits++;
			}

			if (nRayHits == 3)
			{
				m_bCollided = true;
			}
		}

		m_bReversing = false;
	}
}
