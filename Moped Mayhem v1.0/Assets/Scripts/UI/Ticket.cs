// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 29/11/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ticket : MonoBehaviour {
	
	public RawImage m_FoodImage;
	public RawImage m_FoodImageCircle;

	public Slider m_Slider;
	public Image m_TicketImage;

	private float m_fEndTime;
	private float m_fDuration;

	[HideInInspector]
	public Order m_Order;

	[HideInInspector]
	public int m_nTicketPosition;

	[HideInInspector]
	public bool m_bEntering;
	[HideInInspector]
	public bool m_bExiting;
	[HideInInspector]
	public bool m_bMoving;

	[HideInInspector]
	public float m_fLerpEnd;

	public void Start()
	{
		gameObject.SetActive(false);
		enabled = false;
	}

	public void Setup(Order order)
	{
		gameObject.SetActive(true);
		enabled = true;

		m_Order = order;

		m_FoodImage.texture = order.m_Food.m_FoodTexture;
		m_TicketImage.color = order.m_Food.m_TicketColor;
		m_FoodImageCircle.color = order.m_Food.m_TicketColor;

		m_fDuration = order.m_fOrderExiryTime;
		m_fEndTime = Time.time + m_fDuration;

		m_bEntering = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!m_bExiting)
		{
			float currentTime = Time.time;

			float fLerp = 1 - ((m_fEndTime - currentTime) / m_fDuration);

			m_Slider.value = Mathf.Lerp(1.0f, 0.0f, fLerp);
		}
	}
}
