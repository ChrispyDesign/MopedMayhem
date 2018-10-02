// Main Author - Christoper Bowles
//	Alterations by -
//
// Date last worked on 29/09/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class OrderManager : MonoBehaviour
{
	// TEMP
	public GameObject order;

	public Food[] m_Foods;
	private List<string> m_FoodNames = new List<string>();
	private Dictionary<string, int> m_FoodsIndexByName = new Dictionary<string, int>();
	public int[] m_nActiveFoodCount;    //MAKE PRIVATE

	[Range(1.0f, 1.5f)]
	public float m_fFoodWeightModifier = 1.0f;
	private float m_fFoodWeight;

	private int m_nRandomAttemptsMax = 5;
	private int m_nRandomAttempts;

	public float m_fMinSpawnTime = 5.0f;
	public float m_fMaxSpawnTime = 10.0f;
	private float m_fNextSpawnTime;

	public int m_nMaxOrders = 7;

	public float m_fOrderExpiryTime = 10.0f;

	// CB::TODO Hide in inspector after testing
	public List<DeliveryDropoff> m_DropOffLocs = new List<DeliveryDropoff>();
	public List<DeliveryPickup> m_PickUpLocs = new List<DeliveryPickup>();

	// CB::TODO Hide in inspector after testing
	public DeliveryDropoff m_CurrentDropOffZone;
	public DeliveryPickup m_CurrentPickUpZone;

	// CB::TODO Hide in inspector after testing
	public List<DroppedFood> m_DroppedFoodList = new List<DroppedFood>();

	private List<Order> m_ActiveOrders = new List<Order>();
	private List<Order> m_InActiveOrders = new List<Order>();

	public bool tempSpawnButton = false;

	// Use this for initialization
	void Start ()
	{
		// FOR each food in m_Foods
		for (int i = 0; i < m_Foods.Length; ++i)
		{
			// Add name of food to foodNames
			m_FoodNames.Add(m_Foods[i].m_sFoodName);

			// Add index to dictionary with name as key
			m_FoodsIndexByName.Add(m_Foods[i].m_sFoodName, i);
		}

		// Initialise active food count
		m_nActiveFoodCount = new int[m_Foods.Length];

		// Set Food Weight
		m_fFoodWeight = 1.0f / m_Foods.Length * m_fFoodWeightModifier;

		// Set Next Spawn Time
		m_fNextSpawnTime = Time.realtimeSinceStartup + Random.Range(m_fMinSpawnTime, m_fMaxSpawnTime);
	}

	public void AddDropOff(DeliveryDropoff dropOff)
	{
		// IF new Drop off Zone is NOT in list
		if (!m_DropOffLocs.Contains(dropOff))
		{
			// Add to List
			m_DropOffLocs.Add(dropOff);
		}
	}

	public void AddPickUp(DeliveryPickup pickUp)
	{
		// IF new PickUp Zone is NOT in list
		if (!m_PickUpLocs.Contains(pickUp))
		{
			// Add to List
			m_PickUpLocs.Add(pickUp);
		}
	}

	public void NewOrder()
	{
		// TEMP
		order.SetActive(true);

		// Get Random Food
		Food food = RandomFood();

		// Add to Active Food Count
		int index = m_FoodsIndexByName[food.m_sFoodName];
		m_nActiveFoodCount[index]++;

		// Create New Order
		Order newOrder;

		// IF there are inactive orders
		if (m_InActiveOrders.Count > 0)
		{
			// make the inactive order into the new order
			newOrder = m_InActiveOrders[0];

			// remove it from the inactive list
			m_InActiveOrders.RemoveAt(0);
		}
		// ELSE no inactive orders
		else
		{
			// Create a new order
			newOrder = new Order();
		}

		// Set Order variables
		newOrder.m_OrderManager = this;
		newOrder.m_Food = food;
		newOrder.m_fStartTime = Time.realtimeSinceStartup;
		newOrder.m_fOrderExiryTime = m_fOrderExpiryTime;

		// Get Random DropOff Point
		int nTimeOut = 0;
		bool bFindingDropOff = true;
		while (bFindingDropOff)
		{
			int nRandomIndex = Random.Range(0, m_DropOffLocs.Count);
			var randomDropOff = m_DropOffLocs[nRandomIndex];
			if (!randomDropOff.m_bIsActive)
			{
				newOrder.m_DropOffZone = randomDropOff;
				randomDropOff.Activate(newOrder);
				bFindingDropOff = false;
			}
			else
			{
				nTimeOut++;
				if (nTimeOut > 5)
				{
					return;
				}
			}
		}

		// Add Order to active order list
		m_ActiveOrders.Add(newOrder);
	}

	
	private Food RandomFood()
	{
		int nRandom = Random.Range(0, m_Foods.Length);

		if (m_nRandomAttempts < m_nRandomAttemptsMax)
		{
			int nTotalActiveFood = m_ActiveOrders.Count;
			if (nTotalActiveFood > 0)
			{
				if ((float)m_nActiveFoodCount[nRandom] / (float)nTotalActiveFood > m_fFoodWeight)
				{
					m_nRandomAttempts++;
					return RandomFood();
				}
			}
		}

		m_nRandomAttempts = 0;
		return m_Foods[nRandom];
	}

	public void OrderSuccess(Order order)
	{
		// Specific Success Stuff
		this.order.SetActive(false);

		// Run Order Complete
		OrderComplete(order);
	}

	public void OrderFailed(Order order)
	{
		// Specific Failure Stuff

		// Run Order Complete
		OrderComplete(order);
	}

	private void OrderComplete(Order order)
	{
		// Get Index from dictionary
		int nIndex = m_FoodsIndexByName[order.m_Food.m_sFoodName];

		// Decrement active foods
		m_nActiveFoodCount[nIndex]--;

		// Take off Active order list
		m_ActiveOrders.Remove(order);

		// Add to Inactive Order list
		m_InActiveOrders.Add(order);	
	}

	void Update()
	{
		//TEMP
		if(tempSpawnButton)
		{
			NewOrder();
			tempSpawnButton = false;
		}
/*
		float fCurrentTime = Time.realtimeSinceStartup;

		// Check for timed-out/failed orders
		int iter = 0;
		while (iter < m_ActiveOrders.Count)
		{
			// Get current order
			Order order = m_ActiveOrders[iter];

			// IF Order has timed out 
			if (fCurrentTime > (order.m_fStartTime + order.m_fOrderExiryTime))
			{
				// Fail Order
				OrderFailed(order);
			}
			else
			{
				// increment iterator
				iter++;
			}
		}

		// Create New Orders
		// IF we have less than max number of orders
		if (m_ActiveOrders.Count < m_nMaxOrders)
		{
			// IF next spawn time has arrived
			if (m_fNextSpawnTime < fCurrentTime)
			{
				// Make a new order
				NewOrder();

				// Get new random time for next spawn
				m_fNextSpawnTime = fCurrentTime + Random.Range(m_fMinSpawnTime, m_fMaxSpawnTime);
			}
		}
		// ELSE max number of orders
		else
		{
			// Set Next spawn time
			m_fNextSpawnTime = fCurrentTime + m_fMinSpawnTime;
		}
*/
	}
}
