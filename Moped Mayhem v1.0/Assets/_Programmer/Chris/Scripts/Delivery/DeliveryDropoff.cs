﻿// Main Author - Christoper Bowles
//	Alterations by -
//
// Date last worked on 2/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryDropoff : MonoBehaviour {

	public bool m_bIsActive = false;
	public bool m_bPlayerInside = false;
	private OrderManager m_Manager;
	private Order m_ActiveOrder;

	// Use this for initialization
	void Start ()
	{
		m_Manager = FindObjectOfType<OrderManager>();
		m_Manager.AddDropOff(this);
		this.gameObject.SetActive(m_bIsActive);
	}

	public Vector3 GetPos()
	{
		return gameObject.transform.position;
	}

	public void Activate(Order order)
	{
		m_ActiveOrder = order;
		m_bIsActive = true;
		this.gameObject.SetActive(m_bIsActive);
	}

	public void Deactivate()
	{
		m_bIsActive = false;
		this.gameObject.SetActive(m_bIsActive);
		RemoveAsCurrent();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (m_bIsActive == true)
		{
			if (other.CompareTag("Player"))
			{
				m_Manager.m_CurrentDropOffZone = this;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			RemoveAsCurrent();
		}
	}

	private void RemoveAsCurrent()
	{
		if (m_Manager.m_CurrentDropOffZone == this)
		{
			m_Manager.m_CurrentDropOffZone = null;
		}
	}

	public void DropOff(PlayerInventory playerInventory)
	{
		string sOrderFoodName = m_ActiveOrder.m_Food.m_sFoodName;
		if (playerInventory.ContainsFoodOfName(sOrderFoodName))
		{
			// Remove the food
			playerInventory.RemoveFoodByName(sOrderFoodName);

			// Order is complete
			m_ActiveOrder.Success();
			m_bIsActive = false;
			this.gameObject.SetActive(m_bIsActive);

			RemoveAsCurrent();
			//CB::HERENOW
		}
	}
}
