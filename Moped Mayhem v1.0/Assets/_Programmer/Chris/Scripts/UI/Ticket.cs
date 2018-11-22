using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ticket : MonoBehaviour {

	public RawImage m_TicketImage;
	public RawImage m_FoodImage;

	public Slider m_Slider;
	public Image m_Fill;

	public Color m_FullColour;
	public Color m_MidColour;
	public Color m_EmptyColour;

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


			// change color
			Color color = m_Fill.color;
			if (fLerp < 0.5f)
			{
				float fColorLerp = (fLerp * 2);
				color = Color.Lerp(m_FullColour, m_MidColour, fColorLerp);
			}
			else if (fLerp > 0.5f)
			{
				float fColorLerp = ((fLerp - 0.5f) * 2);
				color = Color.Lerp(m_MidColour, m_EmptyColour, fColorLerp);
			}

			m_Fill.color = color;
		}
	}
}
