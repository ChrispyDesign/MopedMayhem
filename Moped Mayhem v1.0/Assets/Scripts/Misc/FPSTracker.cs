using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSTracker : MonoBehaviour {

	public bool m_Active = false;

	[Header("FPS")]
	public float m_MinFPS = float.PositiveInfinity;
	public float m_AvgFPS = 0.0f;
	public float m_FPS = 0.0f;

	private bool m_Logged = false;

	private float m_deltaTime = 0.0f;
			
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("DEBUG"))
		{
			m_Active = !m_Active;
		}

		if (!m_Active)
		{
			return;
		}

		if (Time.timeScale > 0.1f)
		{
			if (m_Logged)
			{
				m_Logged = false;
			}

			m_deltaTime += (Time.unscaledDeltaTime - m_deltaTime) * 0.1f;

			m_FPS = 1.0f / m_deltaTime;

			if (m_MinFPS > m_FPS)
			{
				m_MinFPS = m_FPS;
			}

			if (m_AvgFPS == 0.0f)
			{
				m_AvgFPS = m_FPS;
			}
			else
			{
				m_AvgFPS += m_FPS;
				m_AvgFPS /= 2;
			}
		}
		else
		{
			if (!m_Logged)
			{
				m_Logged = true;

				Debug.LogWarning("Min FPS = " + m_MinFPS + ", Avg FPS = " + m_AvgFPS);
			}
		}
	}
}
