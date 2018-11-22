using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemolisherTempMove : MonoBehaviour {

	public Transform StartPos;
	public Transform EndPos;
	public float fLerpTime;

	public bool bStartLerp;
	private bool bLerping;

	private float fEndTime;


	// Update is called once per frame

	private void Start()
	{
		transform.position = StartPos.position;
	}
	void Update ()
	{
        if (Input.GetKeyUp(KeyCode.Space))
            bStartLerp = true;
        if (bStartLerp)
        {
            fEndTime = Time.time + fLerpTime;
            bStartLerp = false;
            bLerping = true;
            Debug.Log(fEndTime);
        }

        if (bLerping)
        {
            if (fEndTime > Time.time)
            {
                // was dividing by fEndTime instead of fLerpTime - want to get the percentage through the lerp time!
                float fLerp = 1 - ((fEndTime - Time.time) / fLerpTime);

                transform.position = Vector3.Lerp(StartPos.position, EndPos.position, fLerp);
            }
            else
            {
                bLerping = false;
            }
        }
	}
}
