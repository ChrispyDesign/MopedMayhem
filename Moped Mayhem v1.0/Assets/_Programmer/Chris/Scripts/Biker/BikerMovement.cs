using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BikerMovement : MonoBehaviour
{
	public GameObject player;

	public float m_ChaseSpeed;
	public float m_CatchUpSpeed;
	public float m_AttackSpeed;
	public float m_MaxTurnAngle;

	private NavMeshAgent m_NavAgent;

	// Use this for initialization
	void Start ()
	{
		m_NavAgent = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
