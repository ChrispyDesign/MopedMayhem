using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketManager : MonoBehaviour {

	public GameObject m_TicketPrefab;
	public Transform[] m_TicketPositions;

	public float m_fOffscreenOffset;

	public float m_fEnterDuration;
	public float m_fExitDuration;
	public float m_fMovingDuration;

	private List<Ticket> m_ActiveTickets = new List<Ticket>();
	private List<Ticket> m_InactiveTickets = new List<Ticket>();

	private bool[] m_bUsedPositions;

	// Use this for initialization
	void Start ()
	{
		int nTicketPositionCount = m_TicketPositions.Length;

		for (int i = 0; i < nTicketPositionCount + 1; ++i)
		{
			Ticket tempTicket = Instantiate(m_TicketPrefab, gameObject.transform).GetComponent<Ticket>();
			m_InactiveTickets.Add(tempTicket);
		}

		m_bUsedPositions = new bool[m_TicketPositions.Length];
	}
	
	// Update is called once per frame
	void Update ()
	{
		int iter = 0;
		while (iter < m_ActiveTickets.Count)
		{
			Ticket currentTicket = m_ActiveTickets[iter];

			if (!currentTicket.enabled)
			{
				m_ActiveTickets.Remove(currentTicket);
				m_InactiveTickets.Add(currentTicket);
				continue;
			}

			if (currentTicket.m_bEntering)
			{
				Enter(currentTicket);
			}
			else if (currentTicket.m_bExiting)
			{
				Exit(currentTicket);
			}
			else 
			{
				int currentPos = currentTicket.m_nTicketPosition;
				if (currentPos > iter)
				{
					MoveDown(currentTicket, iter);
				}
			}
			++iter;
		}
	}

	private void Enter(Ticket ticket)
	{
		float fCurrentTime = Time.realtimeSinceStartup;

		if (ticket.m_fLerpEnd == 0)
		{
			ticket.m_fLerpEnd = fCurrentTime + m_fEnterDuration;
		}
		else
		{
			ticket.m_nTicketPosition = m_TicketPositions.Length - 1;

			Vector3 v3StartPos = m_TicketPositions[ticket.m_nTicketPosition].position;
			v3StartPos.x -= m_fOffscreenOffset;
			Vector3 v3TargetPos = m_TicketPositions[ticket.m_nTicketPosition].position;

			float fLerpTime = 1 - ((ticket.m_fLerpEnd - fCurrentTime) / m_fEnterDuration);
			ticket.gameObject.transform.position = Vector3.Lerp(v3StartPos, v3TargetPos, fLerpTime);

			if (Vector3.Distance(ticket.transform.position, v3TargetPos) < 0.1f)
			{
				ticket.m_fLerpEnd = 0.0f;
				ticket.m_bEntering = false;
			}
		}
	}

	private void Exit(Ticket ticket)
	{
		float fCurrentTime = Time.realtimeSinceStartup;

		if (ticket.m_fLerpEnd == 0)
		{
			ticket.m_fLerpEnd = fCurrentTime + m_fExitDuration;
		}
		else
		{
			Vector3 v3StartPos = m_TicketPositions[ticket.m_nTicketPosition].position;
			Vector3 v3TargetPos = m_TicketPositions[ticket.m_nTicketPosition].position;
			v3TargetPos.x -= m_fOffscreenOffset;

			float fLerpTime = 1 - ((ticket.m_fLerpEnd - fCurrentTime) / m_fExitDuration);
			ticket.gameObject.transform.position = Vector3.Lerp(v3StartPos, v3TargetPos, fLerpTime);

			if (Vector3.Distance(ticket.transform.position, v3TargetPos) < 0.1f)
			{
				ticket.m_fLerpEnd = 0.0f;
				
				ticket.gameObject.SetActive(false);
				ticket.enabled = false;
				ticket.m_bExiting = false;
			}
		}
	}

	private void MoveDown(Ticket ticket, int nTarget)
	{
		float fCurrentTime = Time.realtimeSinceStartup;

		if (ticket.m_fLerpEnd == 0)
		{
			ticket.m_fLerpEnd = fCurrentTime + m_fMovingDuration;
		}
		else
		{
			Vector3 v3StartPos = m_TicketPositions[ticket.m_nTicketPosition].position;
			Vector3 v3TargetPos = m_TicketPositions[nTarget].position;

			float fLerpTime = 1 - ((ticket.m_fLerpEnd - fCurrentTime) / m_fMovingDuration);
			ticket.gameObject.transform.position = Vector3.Lerp(v3StartPos, v3TargetPos, fLerpTime / (ticket.m_nTicketPosition - nTarget));

			if (Vector3.Distance(ticket.transform.position, v3TargetPos) < 0.1f)
			{
				ticket.m_fLerpEnd = 0.0f;

				ticket.m_nTicketPosition = nTarget;
			}
		}
	}

	public void ActivateTicket(Order order)
	{
		Ticket ticket = m_InactiveTickets[0];
		m_InactiveTickets.RemoveAt(0);
		m_ActiveTickets.Add(ticket);

		int nIndex = m_ActiveTickets.IndexOf(ticket);

		ticket.Setup(order);

		ticket.m_nTicketPosition = nIndex;

		Vector3 v3StartPos = m_TicketPositions[nIndex].position;
		v3StartPos.x -= m_fOffscreenOffset;
		ticket.gameObject.transform.position = v3StartPos;
		
	}

	public void DeactivateTicket(Order order)
	{
		foreach(Ticket ticket in m_ActiveTickets)
		{
			if (ticket.m_Order == order)
			{
				ticket.m_bExiting = true;
				return;
			}
		}

		Debug.LogError("Order of food has no ticket to deactivate" + order.m_Food.m_sFoodName);
	}
}
