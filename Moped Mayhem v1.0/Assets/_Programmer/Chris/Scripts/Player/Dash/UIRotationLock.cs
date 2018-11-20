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