// Main Author - Christoper Bowles
//	Alterations by -
//
// Date last worked on 29/09/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPickup : MonoBehaviour {

	public bool m_bIsActive = false;
	public bool m_bPlayerInside = false;
	private OrderManager m_Manager;
	public Food m_Food;

	// Use this for initialization
	void Start()
	{
		m_Manager = FindObjectOfType<OrderManager>();
		m_Manager.AddPickUp(this);
	}

	public Vector3 GetPos()
	{
		return gameObject.transform.position;
	}

	public void Activate()
	{
		m_bIsActive = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (m_bIsActive == true)
		{
			if (other.CompareTag("Player"))
			{
				m_Manager.m_CurrentPickUpZone = this;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (m_Manager.m_CurrentPickUpZone == this)
			{
				m_Manager.m_CurrentPickUpZone = null;
			}
		}
	}

	public void PickUp(PlayerInventory playerInventory)
	{
		var newFood = Instantiate(m_Food);

		// IF Failed to add
		if (!playerInventory.AddFood(newFood))
		{
			Destroy(newFood);
		}
	}
}
