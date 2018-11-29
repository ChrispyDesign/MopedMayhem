// Main Author - Tim Langford
//	Alterations by - Chris Bowles
// Date last worked on 1/11/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAttack : MonoBehaviour
{
	public int m_nBuildingLayer = 8;

	public Transform m_Player; // Target Player 

    public AudioSource LockedOn, AboutToShoot, Shot;

	public Transform m_BarrelEnd;
	public LineRenderer m_Laser; // Laser from Sniper to player

	public GameObject m_ReticleMainPrefab; // get the main reticle in the scene

	private GameObject	m_ReticleMain, m_ReticleTop, m_ReticleBot,
						m_ReticleLeft, m_ReticleRight; // The Reticle points that will be found in the scene

	public Vector3	m_ReticleTopEnd, m_ReticleBotEnd,	
					m_ReticleLeftEnd, m_ReticleRightEnd; // Reticle End Points

	private Vector3 m_ReticleTopStart, m_ReticleBotStart,
					m_ReticleLeftStart, m_ReticleRightStart; // Reticle Start Points

	[Range(1,10)]
	public float m_fReticleRotationSpeed = 2.0f; // rotation speed of the reticle
	[Range(1,10)]
	public float m_fAttackDuration; // the duration that the sniper attack will last before the attack goes off
	private float m_fAttackEnd; // when the attack ends
	[Range(1, 10)]
	public float m_fCooldown; // cooldown for the sniper
	private float m_fCooldownEnd; // When the cooldown ends

	private bool m_bAttacking; // is the sniper attacking

	private bool m_bCollided = false; // has the sniper been collided with
	private Vector3 m_PrevPos; // what the snipers previous position was

	private Rigidbody m_SniperRB; // the rigid body of the sniper
	private	Vector3 m_Vec3Force; // the force added to the player when attacked

	private Rigidbody m_PlayerRB; // players Rigid body for the sniper shot

	[Range(0,500)]
	public float m_fKnockBack = 2; // the force that will be applied to the player

	private DeathScript m_Death; // snipers death
	private float m_fStartHeight; // snipers starting height
	
	// Use this for initialization
	void Awake()
	{
		m_ReticleMain	= Instantiate<GameObject>(m_ReticleMainPrefab);
		m_ReticleTop	= m_ReticleMain.transform.Find("RetTop").gameObject;
		m_ReticleBot	= m_ReticleMain.transform.Find("RetBot").gameObject;
		m_ReticleLeft	= m_ReticleMain.transform.Find("RetLeft").gameObject;
		m_ReticleRight	= m_ReticleMain.transform.Find("RetRight").gameObject;

		m_ReticleTopStart	= m_ReticleTop.transform.localPosition;
		m_ReticleBotStart	= m_ReticleBot.transform.localPosition;
		m_ReticleLeftStart	= m_ReticleLeft.transform.localPosition;
		m_ReticleRightStart = m_ReticleRight.transform.localPosition;
		m_SniperRB = gameObject.GetComponent<Rigidbody>();

		m_PrevPos = transform.position;

		m_PlayerRB = m_Player.GetComponent<Rigidbody>();
		m_Death = GetComponent<DeathScript>();
		m_Death.m_RelatedObjects.Add(m_ReticleMain);

		m_fStartHeight = transform.position.y;
	}

	// Update is called once per frame
	void Update()
	{

		float fCurrentTime = Time.time; // current time for the countdown timer
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
			
			if(transform.position.y >= 20 + m_fStartHeight)
			{
				m_Death.m_bKillMe = true;
			}

			return;
		}

		RaycastHit hit;
		Vector3 direction = m_Player.position - m_BarrelEnd.position;
		Ray ray = new Ray(m_BarrelEnd.position, direction);

		// This is a bitmask that makes it so we only check the building layer 
		int layerMask = 1 << m_nBuildingLayer;

		// Check to see if we hit a building
		if (Physics.Raycast(ray, out hit, direction.magnitude, layerMask))
		{
            // End the attack
            AboutToShoot.loop = false;
            AboutToShoot.Stop();

            m_bAttacking = false;
			m_fAttackEnd = 0;

			m_ReticleMain.SetActive(false);
			m_Laser.enabled = false;
			return;
		}
		// Else we must have reached the player
		// IF we are not already attacking the player
		else if (!m_bAttacking)
		{
			if (fCurrentTime > m_fCooldownEnd)
			{
                // Start attacking the player
                AboutToShoot.loop = true;
                AboutToShoot.Play();


				// Set Time to end attack
				m_fAttackEnd = fCurrentTime + m_fAttackDuration;
				m_bAttacking = true;

				// Enable reticle and laser
				m_ReticleMain.SetActive(true);
				m_Laser.enabled = true;

				// hit.point - transform.position
			}
		}

		// IF current time is less that time to end attack 
		if (fCurrentTime < m_fAttackEnd)
		{
			// Determine lerp time (between 0-1)
			float fLerpTime = 1 - ((m_fAttackEnd - fCurrentTime) / m_fAttackDuration);

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
		if (fCurrentTime > m_fAttackEnd)
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

                // Make Player Move X distance
                Shot.Play();
				m_PlayerRB.AddForce(direction * m_fKnockBack, ForceMode.Impulse);
				
				var effect = m_Player.GetComponent<PlayerParticles>();
				if (effect == null)
				{
					Debug.LogWarning("Player has no PlayerParticles Component");
				}
				else
				{
					effect.Play(effect.m_SniperHit);
				}

				m_fCooldownEnd = fCurrentTime + m_fCooldown;
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		// Becomes true if we collided with the player
		var tag = collision.gameObject.tag;
		if (tag == "Player" || tag == "Biker")
		{
			m_bCollided = true;
			m_Death.KillAfter(3);
		}
	}
}
