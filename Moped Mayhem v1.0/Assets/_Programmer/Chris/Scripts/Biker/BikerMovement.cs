// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 01/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BikerMovement : MonoBehaviour
{
	public GameObject m_Player;

	public float m_ChaseSpeed;
	public float m_CatchUpSpeed;
	public float m_AttackSpeed;
	public float m_MaxTurnAngle;

	private NavMeshAgent m_NavAgent;

	// Use this for initialization
	void Start()
	{
		m_NavAgent = gameObject.GetComponent<NavMeshAgent>();
	}

	// Manually Gets Path to Player
	public void GetPathToPlayer()
	{
		m_NavAgent.SetDestination(m_Player.transform.position);
	}

	public bool MoveChase()
	{
		return true;
	}

	public bool MoveCatchUp()
	{
		return true;
	}

	public bool MoveAttack()
	{
		return true;
	}
}
