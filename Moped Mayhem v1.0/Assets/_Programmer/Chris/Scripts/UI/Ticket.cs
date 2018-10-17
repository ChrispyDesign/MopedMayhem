using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ticket : MonoBehaviour {

	public RawImage m_TicketImage;
	public RawImage m_FoodImage;
	private Color m_TicketColor;

	public Slider m_Slider;
	public Image m_Fill;

	public Color m_FullColour;
	public Color m_MidColour;
	public Color m_EmptyColour;


	private float m_fEndTime;
	private float m_fDuration;

	[HideInInspector]
	public int m_nTicketPosition;

	public void Setup(RawImage foodImage, Color ticketColor, float fDuration)
	{
		m_FoodImage = foodImage;
		m_TicketImage.color = ticketColor;

		m_fDuration = fDuration;
		m_fEndTime = Time.realtimeSinceStartup + fDuration;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float currentTime = Time.realtimeSinceStartup;

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
