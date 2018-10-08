using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempTicket : MonoBehaviour {

	private float startTime;
	public float duration;

	public Vector3 startOffset;

	private Vector3 pos;
	private Vector3 offPos;
	private bool entering;
	private bool exiting;

	private float endTime;

	public Slider slider;
	public Image fill;

	public Color full;
	public Color mid;
	public Color empty;

	public float lerpTime;
	private float endLerpTime;

	public void Start()
	{
		pos = gameObject.transform.position;
		gameObject.transform.position += startOffset;
		offPos = gameObject.transform.position;
	}

	public void Activate()
	{
		startTime = Time.realtimeSinceStartup;
		endTime = startTime + duration;
		gameObject.SetActive(true);
		entering = true;
	}

	private void Update()
	{
		float currentTime = Time.realtimeSinceStartup;

		float lerp = 1 - ((endTime - currentTime) / duration);

		slider.value = Mathf.Lerp(1.0f, 0.0f, lerp);


		// change color
		Color color = fill.color;
		if (lerp < 0.5f)
		{
			float colorLerp = (lerp * 2);
			color = Color.Lerp(full, mid, colorLerp);			
		}
		else if (lerp > 0.5f)
		{
			float colorLerp = ((lerp - 0.5f) * 2);
			color = Color.Lerp(mid, empty, colorLerp);
		}

		fill.color = color;

		if (lerp > 1.0f)
		{
			exiting = true;
		}

		if (entering)
		{
			if (endLerpTime == 0)
			{
				endLerpTime = Time.realtimeSinceStartup + lerpTime;
			}
			else
			{
				float fLerpTime = 1 - ((endLerpTime - currentTime) / lerpTime);
				gameObject.transform.position = Vector3.Lerp(offPos, pos, fLerpTime);

				if (gameObject.transform.position == pos)
				{

					endLerpTime = 0.0f;
					entering = false;
				}
			}
		}
		else if (exiting)
		{
			if (endLerpTime == 0)
			{
				endLerpTime = Time.realtimeSinceStartup + lerpTime;
			}
			else
			{
				float fLerpTime = 1 - ((endLerpTime - currentTime) / lerpTime);
				gameObject.transform.position = Vector3.Lerp(pos, offPos, fLerpTime);

				if (gameObject.transform.position == offPos)
				{
					endLerpTime = 0.0f;
					Deactivate();
					exiting = false;
				}
			}
		}
	}

	public void Deactivate()
	{
		gameObject.SetActive(false);
	}
}
