using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSniperAttack : MonoBehaviour
{
	public Transform player;

	public Transform barrelEnd;
	public LineRenderer laser;
	public GameObject reticleMain;
	public GameObject reticleTop;
	public GameObject reticleBottom;
	public GameObject reticleLeft;
	public GameObject reticleRight;

	public Vector3 reticleTopEnd;
	public Vector3 reticleBottomEnd;
	public Vector3 reticleLeftEnd;
	public Vector3 reticleRightEnd;

	public float reticleRotationSpeed = 2.0f;

	public float attackDuration;
	private float attackEnd;

	private Vector3 reticleTopStart;
	private Vector3 reticleBottomStart;
	private Vector3 reticleLeftStart;
	private Vector3 reticleRightStart;

	public bool attack = false;


	// Use this for initialization
	void Start ()
	{
		reticleTopStart = reticleTop.transform.localPosition;
		reticleBottomStart = reticleBottom.transform.localPosition;
		reticleLeftStart = reticleLeft.transform.localPosition;
		reticleRightStart = reticleRight.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
	{

		float fCurrentTime = Time.timeSinceLevelLoad;

		gameObject.transform.LookAt(player);

		

		if (Input.GetButtonDown("Fire1") || attack)
		{
			attackEnd = Time.timeSinceLevelLoad + attackDuration;
			attack = false;

			reticleMain.SetActive(true);
			laser.enabled = true;
		}

		if (fCurrentTime < attackEnd)
		{
			RaycastHit hit;
			Vector3 direction = barrelEnd.position - player.position;
			Ray ray = new Ray(barrelEnd.position, direction);
			if (Physics.Raycast(ray, out hit, direction.magnitude))
			{
				if (hit.collider.gameObject.tag != "Player")
				{
					attackEnd = 0;
					return;
				}
			}



			float fLerpTime =  1 - ((attackEnd - fCurrentTime) / attackDuration);

			reticleMain.transform.position = player.position;
			reticleMain.transform.position += reticleMain.transform.up;
			reticleMain.transform.Rotate(0.0f, reticleRotationSpeed, 0.0f);

			reticleTop.transform.localPosition = Vector3.Lerp(reticleTopStart, reticleTopEnd, fLerpTime);
			reticleBottom.transform.localPosition = Vector3.Lerp(reticleBottomStart, reticleBottomEnd, fLerpTime);
			reticleLeft.transform.localPosition = Vector3.Lerp(reticleLeftStart, reticleLeftEnd, fLerpTime);
			reticleRight.transform.localPosition = Vector3.Lerp(reticleRightStart, reticleRightEnd, fLerpTime);


			Vector3[] pos = { barrelEnd.position, player.position + Vector3.up };

			laser.SetPositions(pos);			
		}

		if (fCurrentTime > attackEnd)
		{
			reticleMain.SetActive(false);
			laser.enabled = false;

			reticleTop.transform.position = reticleTopStart;
			reticleBottom.transform.position = reticleBottomStart;
			reticleLeft.transform.position = reticleLeftStart;
			reticleRight.transform.position = reticleRightStart;
		}
	}
}
