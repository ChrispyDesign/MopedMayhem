using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAttack : MonoBehaviour
{
	public Transform m_Player; // Target Player 

	public Transform m_BarrelEnd;
	public LineRenderer m_Laser; // Laser from Sniper to player
	public GameObject m_ReticleMain, m_ReticleTop, m_ReticleBot, m_ReticleLeft, m_ReticleRight; // The Reticle

	public Vector3	m_ReticleTopEnd, m_ReticleBotEnd,	
					m_ReticleLeftEnd, m_ReticleRightEnd; // Reticle End Points

	private Vector3 m_ReticleTopStart, m_ReticleBotStart,
					m_ReticleLeftStart, m_ReticleRightStart; // Reticle Start Points

	public float m_fReticleRotationSpeed = 2.0f;
	public float m_fAttackDuration;
	private float m_fAttackEnd;
	private bool m_bAttacking;

	private bool m_bCollided = false;
	private Vector3 m_PrevPos;

	private Rigidbody m_SniperRB;
	private	Vector3 m_Vec3Force;

	// Use this for initialization
	void Start()
	{
		

		m_ReticleTopStart	= m_ReticleTop.transform.localPosition;
		m_ReticleBotStart	= m_ReticleBot.transform.localPosition;
		m_ReticleLeftStart = m_ReticleLeft.transform.localPosition;
		m_ReticleRightStart = m_ReticleRight.transform.localPosition;
		m_SniperRB = gameObject.GetComponent<Rigidbody>();

		m_PrevPos = transform.position;
	}

	// Update is called once per frame
	void Update()
	{

		float m_fCurrentTime = Time.timeSinceLevelLoad; // current time for the countdown timer
		gameObject.transform.LookAt(m_Player); // snipers will look at the player

		if (!m_bCollided)
		{
			transform.position = m_PrevPos;
		}
		else
		{
			m_PrevPos = transform.position;
			m_Vec3Force.Set(0, 50, 0);
			m_SniperRB.AddForce(m_Vec3Force);
			m_ReticleMain.SetActive(false);
			m_Laser.enabled = false;
			
			if(transform.position.y >= 100)
			{
				gameObject.SetActive(false);
			}
		}

		RaycastHit hit;
		Vector3 direction = m_Player.position - m_BarrelEnd.position;
		 Ray ray = new Ray(m_BarrelEnd.position, direction);

		if (Physics.Raycast(ray, out hit, direction.magnitude + 1))
		{
			// IF what it hit is not the player
			if (hit.collider.gameObject.tag != "Player")
			{

				// End the attack
				m_bAttacking = false;
				m_fAttackEnd = 0;

				m_ReticleMain.SetActive(false);
				m_Laser.enabled = false;
				return;
			}
			else if (hit.collider.gameObject.tag == "Player" && !m_bAttacking)
			{
				// Set Time to end attack
				m_fAttackEnd = Time.timeSinceLevelLoad + m_fAttackDuration;
				m_bAttacking = true;

				m_ReticleMain.SetActive(true);
				m_Laser.enabled = true;

				// hit.point - transform.position
			}
		}
		// IF current time is less that time to end attack 
		if (m_fCurrentTime < m_fAttackEnd)
		{
			// Determine lerp time (between 0-1)
			float fLerpTime = 1 - ((m_fAttackEnd - m_fCurrentTime) / m_fAttackDuration);

			// Set Reticle main position to players current position and a little up
			m_ReticleMain.transform.position = m_Player.position;
			m_ReticleMain.transform.position += m_ReticleMain.transform.up;
			m_ReticleMain.transform.Rotate(0.0f, m_fReticleRotationSpeed, 0.0f);

			// Lerp the reticle segments from their start to end positions 
			m_ReticleTop.transform.localPosition = Vector3.Lerp(m_ReticleTopStart, m_ReticleTopEnd, fLerpTime);
			m_ReticleBot.transform.localPosition = Vector3.Lerp(m_ReticleBotStart, m_ReticleBotEnd, fLerpTime);
			m_ReticleLeft.transform.localPosition = Vector3.Lerp(m_ReticleLeftStart, m_ReticleLeftEnd, fLerpTime);
			m_ReticleRight.transform.localPosition = Vector3.Lerp(m_ReticleRightStart, m_ReticleRightEnd, fLerpTime);

			// Get Positions of barrel end and player
			Vector3[] pos = { m_BarrelEnd.position, m_Player.position + Vector3.up };

			// Show LAZER BEAM between the positions
			m_Laser.SetPositions(pos);
		}
		// IF current time is after attack should end
		if (m_fCurrentTime > m_fAttackEnd)
		{
			// Disable the reticle and laser
			m_ReticleMain.SetActive(false);
			m_Laser.enabled = false;

			// Reset reticle segment positions
			m_ReticleTop.transform.position = m_ReticleTopStart;
			m_ReticleBot.transform.position = m_ReticleBotStart;
			m_ReticleLeft.transform.position = m_ReticleLeftStart;
			m_ReticleRight.transform.position = m_ReticleRightStart;

			// If it was still attacking at the time it ended
			if (m_bAttacking)
			{
				// Stop the attack
				m_bAttacking = false;

				// Make Player take damage
				//Life.TakeDamage();
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			m_bCollided = true;
		}
		else
		{
			m_bCollided = false;
		}
	}
}
