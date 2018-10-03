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
		reticleTopStart = reticleTop.transform.position;
		reticleBottomStart = reticleBottom.transform.position;
		reticleLeftStart = reticleLeft.transform.position;
		reticleRightStart = reticleLeft.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameObject.transform.LookAt(player);

		if (Input.GetButtonDown("Fire1") || attack)
		{
			attackEnd = Time.timeSinceLevelLoad + attackDuration;
			attack = false;

			//reticleMain.SetActive(true);
			laser.enabled = true;
		}

		if (Time.timeSinceLevelLoad < attackEnd)
		{
			reticleMain.transform.position = player.position;
			reticleMain.transform.position += reticleMain.transform.up; 

			reticleTop.transform.position = Vector3.Lerp(reticleTopStart, reticleTopEnd, attackDuration);
			reticleBottom.transform.position = Vector3.Lerp(reticleBottomStart, reticleBottomEnd, attackDuration);
			reticleLeft.transform.position = Vector3.Lerp(reticleLeftStart, reticleLeftEnd, attackDuration);
			reticleRight.transform.position = Vector3.Lerp(reticleRightStart, reticleRightEnd, attackDuration);

			Vector3[] pos = { barrelEnd.position, player.position };

			laser.SetPositions(pos);			
		}

		if (Time.timeSinceLevelLoad > attackEnd)
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
