﻿// Main Author - Christoper Bowles
//	Alterations by -
//
// Date last worked on 23/11/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPickup : MonoBehaviour {

	public bool m_bIsActive = false;
	public bool m_bPlayerInside = false;
	private OrderManager m_Manager;
    public AudioSource Pickup;
	public Food m_RestaurantFood;
	public Food m_OrderFood;


	// Use this for initialization
	void Awake()
	{
		m_Manager = FindObjectOfType<OrderManager>();
		m_Manager.AddPickUp(this);
		this.gameObject.SetActive(m_bIsActive);
	}

	public Vector3 GetPos()
	{
		return gameObject.transform.position;
	}

	public void Activate(Food food)
	{
		m_OrderFood = food;
		m_bIsActive = true;
		this.gameObject.SetActive(m_bIsActive);
        //Pickup.Play();
	}

	public void Deactivate()
	{
		m_OrderFood = null;
		m_bIsActive = false;
		this.gameObject.SetActive(m_bIsActive);

		if (m_Manager.m_CurrentPickUpZone == this)
		{
			m_Manager.m_CurrentPickUpZone = null;
		}
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
		// Attempt to add food
		bool bAddedFood = playerInventory.AddFood(m_OrderFood);

		// IF food added
		if (bAddedFood)
		{
			Deactivate();
		}
	}
}
