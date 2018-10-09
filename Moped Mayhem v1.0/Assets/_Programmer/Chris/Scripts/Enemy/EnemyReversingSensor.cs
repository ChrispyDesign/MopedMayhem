using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReversingSensor : MonoBehaviour {

	public string m_sBuildingTag = "Building";
	public bool m_bActive = false;

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == m_sBuildingTag)
		{
			m_bActive = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == m_sBuildingTag)
		{
			m_bActive = false;
		}
	}
}
