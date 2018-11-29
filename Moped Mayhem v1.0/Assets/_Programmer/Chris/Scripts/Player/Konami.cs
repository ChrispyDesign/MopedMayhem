using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UUDDLRLRBAStart

public class Konami : MonoBehaviour {

	[Header("Debug Button, press once to activate")]
	public bool m_bDebug = false;

	[Header("Parent View Transform")]
	public Transform m_Parent;

	[Header("Rotation Caps (in degrees)")]
	public float m_fUpCap;
	public float m_fDownCap;
	public float m_fHorCap;

	private string m_sKonami = "UUDDLRLRBAS";
	private string m_sCode = "";
	private bool m_bStarted = false;
	private bool m_bKonami = false;

	private bool m_bKonamiUp = false;
	private bool m_bKonamiDown = false;
	private bool m_bKonamiLeft = false;
	private bool m_bKonamiRight = false;

	private float m_fExpiryTime = 15.0f;
	private float m_fTimeEnd;

	private _BCameraController m_CameraController;

	// Use this for initialization
	void Awake ()
	{
		m_CameraController = Camera.main.GetComponent<_BCameraController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Debug the konami
		if (m_bDebug)
		{
			m_bDebug = false;

			// IF Konami mode is not active
			if (!m_bKonami)
			{
				// Start Konami mode
				KonamiStart();
			}
			else
			{
				// End Konami mode
				KonamiEnd();
			}
		}

		// Check for start of konami code
		if (Input.GetAxis("Konami Up") > 0.5f && !m_bKonamiUp)
		{
			if (m_bStarted == false)
			{
				m_bStarted = true;
				m_fTimeEnd = Time.time + m_fExpiryTime;
			}

			m_bKonamiUp = true;
			Debug.Log("Up");
			m_sCode += "U";
		}

		// IF konami code started
		if (m_bStarted)
		{ 
			// Check the other inputs
			if (Input.GetAxis("Konami Down") > 0.5f && !m_bKonamiDown)
			{
				m_bKonamiDown = true;
				Debug.Log("Down");
				m_sCode += "D";
			}
			if (Input.GetAxis("Konami Left") > 0.5f && !m_bKonamiLeft)
			{
				// Because Left is shared with A check if it should logically be L
				if (!m_sCode.Contains("UUDDLRLR"))
				{
					m_bKonamiLeft = true;
					Debug.Log("Left");
					m_sCode += "L";
				}
			}
			if (Input.GetAxis("Konami Right") > 0.5f && !m_bKonamiRight)
			{
				m_bKonamiRight = true;
				Debug.Log("Right");
				m_sCode += "R";
			}
			if (Input.GetButtonDown("Konami A"))
			{
				// Because Left is shared with A check if it should logically be A
				if (m_sCode.Contains("UUDDLRLR"))
				{
					Debug.Log("A");
					m_sCode += "A";
				}
			}
			if (Input.GetButtonDown("Konami B"))
			{
				Debug.Log("B");
				m_sCode += "B";
			}
			if (Input.GetButtonDown("Konami Start"))
			{
				Debug.Log("Start");
				m_sCode += "S";
			}

			// Check Code is correct
			string sTest = m_sKonami.Remove(m_sCode.Length, m_sKonami.Length - m_sCode.Length);

			// IF code is not correct
			if (sTest != m_sCode)
			{
				// Restart sequence
				Debug.LogWarning(sTest + " , " + m_sCode);
				m_bStarted = false;
				m_sCode = "";
			}
			// ELSE IF code is the same length as the konami code
			else if (m_sCode.Length == m_sKonami.Length)
			{
				m_bStarted = false;
				m_sCode = "";

				// IF Konami mode is not active
				if (!m_bKonami)
				{
					// Start Konami mode
					KonamiStart();
				}
				else
				{
					// End Konami mode
					KonamiEnd();
				}
			}

			// Time Out
			if (Time.time > m_fTimeEnd)
			{
				m_bStarted = false;
				m_sCode = "";
			}
		}

		// Reset bools
		if (Input.GetAxis("Konami Up") < 0.5f && m_bKonamiUp)
		{
			m_bKonamiUp = false;
		}
		if (Input.GetAxis("Konami Down") < 0.5f && m_bKonamiDown)
		{
			m_bKonamiDown = false;
		}
		if (Input.GetAxis("Konami Left") < 0.5f && m_bKonamiLeft)
		{
			m_bKonamiLeft = false;
		}
		if (Input.GetAxis("Konami Right") < 0.5f && m_bKonamiRight)
		{
			m_bKonamiRight = false;
		}
	}

	private void FixedUpdate()
	{
		if (Input.GetJoystickNames().Length > 0)
		{
			Debug.LogWarning(Input.GetJoystickNames()[0]);
		}
		else
		{
			Debug.LogWarning("WTF");
		}

		// IF konami mode active
		if (m_bKonami)
		{
			KonamiUpdate();
		}
	}

	private void KonamiStart()
	{
		Debug.LogWarning("KONAMI BITCHES");
		m_bKonami = true;

		transform.SetParent(m_Parent, false);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;

		Camera.main.fieldOfView = 80.0f;

		m_CameraController.enabled = false;
	}

	private void KonamiEnd()
	{
		Debug.LogWarning("KONAMI OVER :(");
		m_bKonami = false;

		Camera.main.fieldOfView = 30.0f;

		m_Parent.DetachChildren();
		m_CameraController.enabled = true;
	}

	private void KonamiUpdate()
	{
		float fDeltaTime = Time.fixedDeltaTime;

		float fVer = Input.GetAxis("Konami Vertical");
		float fHor = Input.GetAxis("Konami Horizontal");

		var rot = transform.localRotation;
		var v3Euler = rot.eulerAngles;

		// Look Vertical
		v3Euler.x += fVer * fDeltaTime * 60.0f;
		// CB::HERENOW
		if (v3Euler.x < 360.0f - m_fUpCap && v3Euler.x > m_fDownCap)
		{
			if (v3Euler.x < 180.0f)
			{
				v3Euler.x = m_fDownCap;
			}
			else
			{
				v3Euler.x = 360.0f - m_fUpCap;
			}
		}

		//Look Horizontal
		v3Euler.y += fHor * fDeltaTime * 60.0f;

		if (v3Euler.y < 360 - m_fHorCap && v3Euler.y > m_fHorCap)
		{
			if (v3Euler.y < 180.0f)
			{
				v3Euler.y = m_fHorCap;
			}
			else
			{
				v3Euler.y = 360 - m_fHorCap;
			}
		}

		// Zero out z rotation
		v3Euler.z = 0;

		// Put new rotation into transform
		rot.eulerAngles = v3Euler;
		transform.localRotation = rot;
	}
}
