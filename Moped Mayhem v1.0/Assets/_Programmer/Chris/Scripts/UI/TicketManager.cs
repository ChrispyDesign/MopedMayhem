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
			Ticket tempTicket = Instantiate(m_TicketPrefab, gameObject.transform).GetComponent<Ticket>();
			m_InactiveTickets.Add(tempTicket);
		}
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
				int nPosBelow = currentTicket.m_nTicketPosition - 1;
				if (nPosBelow >= 0)
				{
					if (!m_bTakenPostions[nPosBelow])
					{
						MoveDown(currentTicket);
					}
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
			Vector3 v3StartPos = m_TicketPositions[ticket.m_nTicketPosition].position;
			v3StartPos.x -= m_fOffscreenOffset;
			Vector3 v3TargetPos = m_TicketPositions[ticket.m_nTicketPosition].position;

			float fLerpTime = 1 - ((ticket.m_fLerpEnd - fCurrentTime) / m_fEnterDuration);
			ticket.gameObject.transform.position = Vector3.Lerp(v3StartPos, v3TargetPos, fLerpTime);

			if (ticket.gameObject.transform.position == v3TargetPos)
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

			if (ticket.gameObject.transform.position == v3TargetPos)
			{
				ticket.m_fLerpEnd = 0.0f;

				m_bTakenPostions[ticket.m_nTicketPosition] = false;
				ticket.gameObject.SetActive(false);
				ticket.enabled = false;
				ticket.m_bExiting = false;
			}
		}
	}

	private void MoveDown(Ticket ticket)
	{
		float fCurrentTime = Time.realtimeSinceStartup;

		if (ticket.m_fLerpEnd == 0)
		{
			ticket.m_fLerpEnd = fCurrentTime + m_fMovingDuration;
		}
		else
		{
			Vector3 v3StartPos = m_TicketPositions[ticket.m_nTicketPosition].position;
			Vector3 v3TargetPos = m_TicketPositions[ticket.m_nTicketPosition - 1].position;

			float fLerpTime = 1 - ((ticket.m_fLerpEnd - fCurrentTime) / m_fMovingDuration);
			ticket.gameObject.transform.position = Vector3.Lerp(v3StartPos, v3TargetPos, fLerpTime);

			if (ticket.gameObject.transform.position == v3TargetPos)
			{
				ticket.m_fLerpEnd = 0.0f;

				m_bTakenPostions[ticket.m_nTicketPosition] = false;
				ticket.m_nTicketPosition--;
				m_bTakenPostions[ticket.m_nTicketPosition] = true;
			}
		}
	}

	public void ActivateTicket(Order order)
	{
		Ticket ticket = m_InactiveTickets[0];
		m_InactiveTickets.RemoveAt(0);

		ticket.Setup(order);

		int nTicketPositionCount = m_TicketPositions.Length;

		for (int i = 0; i < nTicketPositionCount; ++i)
		{
			if (!m_bTakenPostions[i])
			{
				m_bTakenPostions[i] = true;
				ticket.m_nTicketPosition = i;

				Vector3 v3StartPos = m_TicketPositions[i].position;
				v3StartPos.x -= m_fOffscreenOffset;
				ticket.gameObject.transform.position = v3StartPos;

				break;
			}
		}

		m_ActiveTickets.Add(ticket);
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

		Debug.LogError("Order of food has no ticket to deactivate", order.m_Food);
	}
}
