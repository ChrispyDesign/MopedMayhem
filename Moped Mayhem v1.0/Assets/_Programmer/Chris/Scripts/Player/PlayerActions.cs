// Main Author - Christoper Bowles
//	Alterations by -
//
// Date last worked on 29/09/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
	public OrderManager m_OrderManager;
    public PlayerInventory m_PlayerInventory;
    public AudioSource CollectOrder;

    public string m_sContextButton = "ContextButton";
	public bool m_bTestContext = true;		// Remove after testing
	public string m_sDropLeft = "DropLeft";
	public bool m_bTestLeft = false;        // Remove after testing
	public string m_sDropRight = "DropRight";
	public bool m_bTestRight = false;       // Remove after testing

	// Use this for initialization
	void Start ()
	{
		if (m_OrderManager == null)
		{
			m_OrderManager = FindObjectOfType<OrderManager>();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		// IF Contextual Button Pressed
		if (Input.GetButtonDown(m_sContextButton) || m_bTestContext)
		{
			PerformContextual();
		}

		// IF DropLeft Button Pressed
		if (Input.GetButtonDown(m_sDropLeft) || m_bTestLeft)
		{
			m_bTestLeft = false;
			m_PlayerInventory.DropLeftFood();
		}

		// IF DropRight Button Pressed
		if (Input.GetButtonDown(m_sDropRight) || m_bTestRight)
		{
			m_bTestRight = false;
			m_PlayerInventory.DropRightFood();
		}
	}

	private void PerformContextual()
	{
		// Get current drop off zone
		var currentDropOffZone = m_OrderManager.m_CurrentDropOffZone;
		var currentPickUpZone = m_OrderManager.m_CurrentPickUpZone;

		// IF current drop off zone exists
		if (currentDropOffZone)
		{
			// Attempt to drop off food from inventory
			currentDropOffZone.DropOff(m_PlayerInventory);
		}

		// IF there is dropped food
		if (m_OrderManager.m_DroppedFoodList.Count > 0)
		{
			// Get first in dropped food list
			var droppedFood = m_OrderManager.m_DroppedFoodList[0];

			// IF Dropped Food is colliding with player
			if (droppedFood.m_bColliding)
			{
				// Add food to player inventory
				bool success = m_PlayerInventory.AddFood(droppedFood.m_Food);

				// IF Successfully added food
				if (success)
				{
					// Delete Dropped food
					droppedFood.Delete();
					return;
				}
			}
		}

		// IF Current PickUp Zone exists
		if (currentPickUpZone)
		{
			// Pick up new food
			currentPickUpZone.PickUp(m_PlayerInventory);
            CollectOrder.Play();
		}
	}
}