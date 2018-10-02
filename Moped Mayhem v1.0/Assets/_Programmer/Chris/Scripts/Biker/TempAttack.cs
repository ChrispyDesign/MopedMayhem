using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempAttack : MonoBehaviour {

	public Transform player;
	public GameObject wood;
	public float fAttackDuration;
	public float fAttackSpeed;

	public bool bDrawWood;
	public bool bAttack;
	public bool bReset;

	private bool bCanMove = true;
	private bool bAttackOngoing = true;
	private bool bAttackSetup = true;
	private float fAttackEndTime;

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			bAttack = true;
		}

		// Draw 2x4
		if (bDrawWood)
		{
			bDrawWood = false;
			wood.SetActive(true);
		}

		// Attack
		if (bAttack)
		{
			bCanMove = false;
			if (bAttackSetup)
			{
				transform.LookAt(player);
				fAttackEndTime = Time.realtimeSinceStartup + fAttackDuration;
				bAttackSetup = false;
				wood.transform.Rotate(0, 90.0f, 90.0f);
			}
			if (bAttackOngoing)
			{
				transform.position += transform.forward * Time.deltaTime * fAttackSpeed;
				if (Time.realtimeSinceStartup > fAttackEndTime)
				{
					bAttackOngoing = false;
				}

			}
			else
			{
				bAttack = false;
				bAttackSetup = true;
				bAttackOngoing = true;
				bCanMove = true;
				wood.transform.Rotate(-90.0f, -90.0f, 0);
			}
		}

		// MOVE
		if (bCanMove)
		{
			transform.LookAt(player);
			transform.position += transform.forward * Time.deltaTime;
		}
	}
}
