using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketManager : MonoBehaviour {

	public GameObject m_TicketPrefab;
	public Transform[] m_TicketPositions;

	public float m_fOffscreenOffset;

	private bool[] m_bTakenPostions;
	private List<Ticket> m_ActiveTickets = new List<Ticket>();
	private List<Ticket> m_InactiveTickets = new List<Ticket>();

	// Use this for initialization
	void Start ()
	{
		int nTicketPositionCount = m_TicketPositions.Length;
		m_bTakenPostions = new bool[nTicketPositionCount];

		for (int i = 0; i < nTicketPositionCount + 1; ++i)
		{
			Ticket tempTicket = Instantiate(m_TicketPrefab).GetComponent<Ticket>();
			m_InactiveTickets.Add(tempTicket);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	private void Enter(Ticket ticket)
	{
		//if (endLerpTime == 0)
		//{
		//	endLerpTime = Time.realtimeSinceStartup + lerpTime;
		//}
		//else
		//{
		//	float fLerpTime = 1 - ((endLerpTime - currentTime) / lerpTime);
		//	gameObject.transform.position = Vector3.Lerp(offPos, pos, fLerpTime);

		//	if (gameObject.transform.position == pos)
		//	{

		//		endLerpTime = 0.0f;
		//		entering = false;
		//	}
		//}
	}

	private void Exit(Ticket ticket)
	{
		//if (endLerpTime == 0)
		//{
		//	endLerpTime = Time.realtimeSinceStartup + lerpTime;
		//}
		//else
		//{
		//	float fLerpTime = 1 - ((endLerpTime - currentTime) / lerpTime);
		//	gameObject.transform.position = Vector3.Lerp(pos, offPos, fLerpTime);

		//	if (gameObject.transform.position == offPos)
		//	{
		//		endLerpTime = 0.0f;
		//		Deactivate();
		//		exiting = false;
		//	}
		//}
	}

	private void MoveDown(Ticket ticket)
	{
		//if (endLerpTime == 0)
		//{
		//	endLerpTime = Time.realtimeSinceStartup + lerpTime;
		//}
		//else
		//{
		//	float fLerpTime = 1 - ((endLerpTime - currentTime) / lerpTime);
		//	gameObject.transform.position = Vector3.Lerp(pos, offPos, fLerpTime);

		//	if (gameObject.transform.position == offPos)
		//	{
		//		endLerpTime = 0.0f;
		//		Deactivate();
		//		exiting = false;
		//	}
		//}
	}

	public void ActivateTicket(Order order)
	{

	}
}
