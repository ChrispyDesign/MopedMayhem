using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSniperAttack : MonoBehaviour
{
	public Transform player;

	public TempHeart life;

	public Transform barrelEnd;
	public LineRenderer laser;
	public GameObject reticleMain;		// This is an empty gameObject representing the center of the reticle
	public GameObject reticleTop;		// top segment of the reticle
	public GameObject reticleBottom;	// bottom segment of the reticle
	public GameObject reticleLeft;		// Left segement of the reticle
	public GameObject reticleRight;     // Right segement of the reticle

	public Vector3 reticleTopEnd;		// Relative end position of the top segment
	public Vector3 reticleBottomEnd;    // Relative bottom position of the top segment
	public Vector3 reticleLeftEnd;      // Relative left position of the top segment
	public Vector3 reticleRightEnd;     // Relative right position of the top segment

	public float reticleRotationSpeed = 2.0f;

	public float attackDuration;
	private float attackEnd;

	private bool bAttacking = false;
	

	private Vector3 reticleTopStart;
	private Vector3 reticleBottomStart;
	private Vector3 reticleLeftStart;
	private Vector3 reticleRightStart;

	public bool attack = false;


	// Use this for initialization
	void Start ()
	{
		// Store starting positions of the reticle segements
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
			// Set Time to end attack
			attackEnd = Time.timeSinceLevelLoad + attackDuration;
			attack = false;
			bAttacking = true;

			reticleMain.SetActive(true);
			laser.enabled = true;
		}

		// IF current time is less that time to enda attack 
		if (fCurrentTime < attackEnd)
		{
			// Determine lerp time (between 0-1)
			float fLerpTime =  1 - ((attackEnd - fCurrentTime) / attackDuration);

			// Set Reticle main position to players current position and a little up
			reticleMain.transform.position = player.position;
			reticleMain.transform.position += reticleMain.transform.up;
			reticleMain.transform.Rotate(0.0f, reticleRotationSpeed, 0.0f);

			// Lerp the reticle segments from their start to end positions 
			reticleTop.transform.localPosition = Vector3.Lerp(reticleTopStart, reticleTopEnd, fLerpTime);
			reticleBottom.transform.localPosition = Vector3.Lerp(reticleBottomStart, reticleBottomEnd, fLerpTime);
			reticleLeft.transform.localPosition = Vector3.Lerp(reticleLeftStart, reticleLeftEnd, fLerpTime);
			reticleRight.transform.localPosition = Vector3.Lerp(reticleRightStart, reticleRightEnd, fLerpTime);

			// Get Positions of barrel end and player
			Vector3[] pos = { barrelEnd.position, player.position + Vector3.up };

			// Show LAZER BEAM between the positions
			laser.SetPositions(pos);

			// Raycast between between positions
			RaycastHit hit;
			Vector3 direction = barrelEnd.position - player.position;
			Ray ray = new Ray(barrelEnd.position, direction);

			// IF Raycast hit something
			if (Physics.Raycast(ray, out hit, direction.magnitude + 1))
			{
				// IF what it hit is not the player
				if (hit.collider.gameObject.tag != "Player")
				{
					// End the attack
					bAttacking = false;
					attackEnd = 0;
					return;
				}
			}
		}

		// IF current time is after attack should end
		if (fCurrentTime > attackEnd)
		{
			// Disable the reticle and laser
			reticleMain.SetActive(false);
			laser.enabled = false;

			// Reset reticle segment positions
			reticleTop.transform.position = reticleTopStart;
			reticleBottom.transform.position = reticleBottomStart;
			reticleLeft.transform.position = reticleLeftStart;
			reticleRight.transform.position = reticleRightStart;

			// If it was still attacking at the time it ended
			if (bAttacking)
			{
				// Stop the attack
				bAttacking = false;

				// Make Player take damage
				life.TakeDamage();
			}
		}
	}
}
