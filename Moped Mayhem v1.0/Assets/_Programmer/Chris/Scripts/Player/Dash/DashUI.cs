using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashUI : MonoBehaviour {

	public Slider m_Slider;

	public bool m_bStartCharged = false;

	private bool m_bCharge = false;
	private float m_fMaxCharge = 1.0f;

	private float m_fCurrentCharge;
	private float m_fStartTime;

	[Header("Flash")]
	public bool m_bCanFlash = true;
	[Range(0, 10)]
	public int m_nFlashCount = 2;
	[Range(0.0f, 1.0f)]
	public float m_fOnDuration = 0.5f;
	[Range(0.0f, 1.0f)]
	public float m_fOffDuration = 0.5f;

	private float m_fToggleDuration;
	private int m_nCurrentFlashCount;
	private bool m_bToggleState = true;

	// Use this for initialization
	void Awake ()
	{
		m_fCurrentCharge = 0.0f;
		if (m_bStartCharged)
		{
			m_fCurrentCharge = m_fMaxCharge;
			m_Slider.gameObject.SetActive(false);
		}

		m_fStartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!m_bCharge)
		{
			return;
		}

		Charge();

		if (m_fCurrentCharge > m_fMaxCharge * 0.8f)
		{
			Flash();
		}
	}
	
	public void StartCharge(float fMaxCharge)
	{
		m_Slider.gameObject.SetActive(true);
		m_Slider.enabled = true;
		m_fMaxCharge = fMaxCharge;
		m_fStartTime = Time.time;
		m_bCharge = true;

		m_nCurrentFlashCount = 0;
	}

	private void Charge()
	{
		m_fCurrentCharge = Time.time - m_fStartTime;

		m_Slider.maxValue = m_fMaxCharge;
		m_Slider.value = m_fCurrentCharge;
	}

	private void Flash()
	{
		float fCurrentTime = Time.time;

		if (m_nCurrentFlashCount > m_nFlashCount || !m_bCanFlash)
		{
			m_bCharge = false;
			m_Slider.gameObject.SetActive(false);
		}

		if (fCurrentTime > m_fToggleDuration)
		{
			if (m_bToggleState)
			{
				m_fToggleDuration = fCurrentTime + m_fOnDuration;
			}
			else
			{
				m_fToggleDuration = fCurrentTime + m_fOffDuration;
			}

			m_Slider.gameObject.SetActive(m_bToggleState);
			m_bToggleState = !m_bToggleState;
			m_nCurrentFlashCount++;
		}
	}
}
