using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerLean : MonoBehaviour {

	public Transform m_CharMain;
	private Rigidbody m_BikerRB;

	public float m_fMaxLean;

	// Use this for initialization
	void Start ()
	{
		m_BikerRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		var velocity = m_BikerRB.velocity;

		float fAngluarY = m_BikerRB.angularVelocity.y;
		float fMaxAngular = m_BikerRB.maxAngularVelocity;

		float fRatio = fAngluarY / fMaxAngular;
		fRatio = Mathf.Clamp(fRatio, -1.0f, 1.0f);

		float fLerp = Mathf.LerpUnclamped(0, m_fMaxLean, fRatio);

		// Check Direction of travel
		float fDir = Vector3.Dot(velocity, transform.forward);
		if (fDir > 0)
		{
			fLerp *= -1;
		}

		m_CharMain.localRotation = new Quaternion(0, 0, fLerp, 1);
	}
}
