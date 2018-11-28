using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UUDDLRLRABStart

public class Konami : MonoBehaviour {

	public bool m_bKonami = false;

	private string m_sKonami = "UUDDLRLRABS";
	private string m_sCode = "";
	private bool m_bStarted = false;

	private _BCameraController m_CameraController;

	// Use this for initialization
	void Awake ()
	{
		m_CameraController = Camera.main.GetComponent<_BCameraController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (m_bKonami)
		{
			KonamiUpdate();
			return;
		}

		if (Input.GetAxis("Konami Up") > 0.5f)
		{
			if (m_bStarted == false)
			{
				m_bStarted = true;
			}

			Debug.Log("Up");
			m_sCode += "U";
		}

		if (!m_bStarted)
		{
			return;
		}

		if (Input.GetAxis("Konami Down") > 0.5f)
		{
			Debug.Log("Down");
			m_sCode += "D";
		}
		else if (Input.GetAxis("Konami Left") > 0.5f)
		{
			Debug.Log("Left");
			m_sCode += "L";
		}
		else if (Input.GetAxis("Konami Right") > 0.5f)
		{
			Debug.Log("Right");
			m_sCode += "R";
		}
		else if (Input.GetButtonUp("Konami A"))
		{
			Debug.Log("A");
			m_sCode += "A";
		}
		else if (Input.GetButtonUp("Konami B"))
		{
			Debug.Log("B");
			m_sCode += "B";
		}
		else if (Input.GetButtonUp("Konami Start"))
		{
			Debug.Log("Start");
			m_sCode += "S";
		}


	}

	private void KonamiStart()
	{

	}

	private void KonamiUpdate()
	{

	}
}
