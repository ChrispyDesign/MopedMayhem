using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemolisherTempAttack : MonoBehaviour
{
	public Transform player;
	public GameObject hitman;
	public GameObject rocketLauncher;
	public GameObject rocket;
	public float fAttackDuration;
	public float fAttackSpeed;

	private GameObject firedRocket;

	public bool bShowHitman;
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

		// Draw Hitman
		if (bShowHitman)
		{
			bShowHitman = false;
			hitman.SetActive(true);
		}

		// Make Hitman Look at player
		hitman.transform.LookAt(player);

		// Attack
		if (bAttack)
		{
			bCanMove = false;
			if (bAttackSetup)
			{
				// Fire Rocket
				firedRocket = Instantiate<GameObject>(rocket);
				firedRocket.transform.position = rocketLauncher.transform.position;
				firedRocket.transform.rotation = rocketLauncher.transform.rotation;
				fAttackEndTime = Time.realtimeSinceStartup + fAttackDuration;
				bAttackSetup = false;
			}
			if (bAttackOngoing)
			{
				// Track/Move Rocket
				firedRocket.transform.position += firedRocket.transform.forward * Time.deltaTime * fAttackSpeed;

				// Check for end of attack
				if (Time.realtimeSinceStartup > fAttackEndTime)
				{					
					bAttackOngoing = false;
				}

			}
			// Attack Ended
			else
			{
				bAttack = false;
				bAttackSetup = true;
				bAttackOngoing = true;
				bCanMove = true;
				Destroy(firedRocket);
			}
		}

		// MOVE
		if (bCanMove && false)
		{
			transform.LookAt(player);
			transform.position += transform.forward * Time.deltaTime;
		}
	}

}
