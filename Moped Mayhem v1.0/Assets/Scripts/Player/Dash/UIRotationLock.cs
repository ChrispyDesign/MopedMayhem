// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 29/11/18

using UnityEngine;

public class UIRotationLock : MonoBehaviour
{
	private Quaternion m_StartRot;

	private void Awake()
	{
		m_StartRot = transform.parent.localRotation;
	}

	private void Update()
	{
		transform.rotation = m_StartRot;
	}
}