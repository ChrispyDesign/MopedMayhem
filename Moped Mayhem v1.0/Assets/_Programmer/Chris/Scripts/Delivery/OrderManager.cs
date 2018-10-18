// Main Author - Christoper Bowles
//	Alterations by -
//
// Date last worked on 29/09/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
	// TEMP
	public Text score;

	public Texture m_IconOnScreen;
	public Texture m_IconOffScreen;
	
	public TicketManager m_TicketManager;
	public PlayerInventory m_PlayerInventory;

	public Food[] m_Foods;
	private List<string> m_FoodNames = new List<string>();
	private Dictionary<string, int> m_FoodsIndexByName = new Dictionary<string, int>();
	private int[] m_nActiveFoodCount;    //MAKE PRIVATE

	[Range(1.0f, 1.5f)]
	private float m_fFoodWeightModifier = 1.0f;
	private float m_fFoodWeight;

	private int m_nRandomAttemptsMax = 5;
	private int m_nRandomAttempts;

	public float m_fMinSpawnTime = 5.0f;
	public float m_fMaxSpawnTime = 10.0f;
	private float m_fNextSpawnTime;

	public int m_nMaxOrders = 7;

	public float m_fOrderExpiryTime = 10.0f;

	[Header("DONT ADD ANYTHING TO THESE")]
	public List<DeliveryDropoff> m_DropOffZones = new List<DeliveryDropoff>();
	public List<DeliveryPickup> m_PickUpZones = new List<DeliveryPickup>();

	public DeliveryDropoff m_CurrentDropOffZone;
	public DeliveryPickup m_CurrentPickUpZone;

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
		if (!m_DropOffZones.Contains(dropOff))
		{
			// Add to List
			m_DropOffZones.Add(dropOff);
		}
	}

	public void AddPickUp(DeliveryPickup pickUp)
	{
		// IF new PickUp Zone is NOT in list
		if (!m_PickUpZones.Contains(pickUp))
		{
			// Add to List
			m_PickUpZones.Add(pickUp);
		}
	}

	public void NewOrder()
	{
		

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


		// Get Random DropOff Point
		int nTimeOut = 0;
		bool bFindingDropOff = true;
		while (bFindingDropOff)
		{
			int nRandomIndex = Random.Range(0, m_DropOffZones.Count);
			var randomDropOff = m_DropOffZones[nRandomIndex];
			if (!randomDropOff.m_bIsActive)
			{
				newOrder.m_DropOffZone = randomDropOff;
				bFindingDropOff = false;
			}
			else
			{
				nTimeOut++;
				if (nTimeOut > 5)
				{
					m_nActiveFoodCount[index]--;
					m_InActiveOrders.Add(newOrder);
					return;
				}
			}
		}

		// Set Order variables
		newOrder.m_OrderManager = this;
		newOrder.m_Food = Instantiate(food);
		newOrder.m_fStartTime = Time.realtimeSinceStartup;
		newOrder.m_fOrderExiryTime = m_fOrderExpiryTime;

		// Add Order to active order list
		m_ActiveOrders.Add(newOrder);

		// Activate Pickup zone
		ActivatePickup(newOrder.m_Food);

		// Activate Dropoff zone
		newOrder.m_DropOffZone.Activate(newOrder);

		// UI STUFF
		m_TicketManager.ActivateTicket(newOrder);
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
		float fScore = float.Parse(score.text);
		float fTimeLeft = (order.m_fOrderExiryTime + order.m_fStartTime) - Time.realtimeSinceStartup;
		fScore += fTimeLeft * 4;
		int nScore = (int)fScore;
		score.text = nScore.ToString();		

		// Run Order Complete
		OrderComplete(order);
	}

	public void OrderFailed(Order order)
	{
		// Specific Failure Stuff
		float fScore = float.Parse(score.text);
		fScore -= 10;
		score.text = fScore.ToString();


		// Run Order Complete
		OrderComplete(order);
	}

	private void OrderComplete(Order order)
	{
		// Deactivate Ticket
		m_TicketManager.DeactivateTicket(order);

		// Get Index from dictionary
		int nIndex = m_FoodsIndexByName[order.m_Food.m_sFoodName];

		// Decrement active foods
		m_nActiveFoodCount[nIndex]--;

		// Take off Active order list
		m_ActiveOrders.Remove(order);

		// Add to Inactive Order list
		m_InActiveOrders.Add(order);


		// Disable Pickup and Drop off zones
		order.m_DropOffZone.Deactivate();
		DeactivatePickup(order.m_Food);

		// Destroy Food parent gameObject
		Destroy(order.m_Food.gameObject);
		m_PlayerInventory.RemoveFoodByName(order.m_Food.m_sFoodName);

		Destroy(order.m_DeliveryIndicator.m_FoodImage);
		Destroy(order.m_DeliveryIndicator.m_IconImage);
		Destroy(order.m_DeliveryIndicator);
		order.m_DeliveryIndicator = null;
	}

	private void ActivatePickup(Food food)
	{
		foreach (DeliveryPickup zone in m_PickUpZones)
		{
			if (zone.m_RestaurantFood.m_sFoodName == food.m_sFoodName)
			{
				zone.Activate(food);
				return;
			}
		}
	}

	private void DeactivatePickup(Food food)
	{
		foreach (DeliveryPickup zone in m_PickUpZones)
		{
			if (zone.m_OrderFood == food)
			{
				zone.Deactivate();
				return;
			}
		}
	}

	private void CheckIndicators()
	{
		foreach (Order order in m_ActiveOrders)
		{
			string sFoodName = order.m_Food.m_sFoodName;
			if (m_PlayerInventory.ContainsFoodOfName(sFoodName))
			{
				if (order.m_DeliveryIndicator == null)
				{
					order.m_DeliveryIndicator = order.m_DropOffZone.gameObject.AddComponent<_DeliveryIndicator>();
					order.m_DeliveryIndicator.m_TargetIconOffScreen = m_IconOffScreen;
					order.m_DeliveryIndicator.m_TargetIconOnScreen = m_IconOnScreen;
					order.m_DeliveryIndicator.m_IconImage.texture = m_IconOnScreen;
					order.m_DeliveryIndicator.m_IconImage.color = order.m_Food.m_TicketColor;
					order.m_DeliveryIndicator.m_IconImage.transform.localScale = Vector3.one;
					order.m_DeliveryIndicator.m_FoodImage.texture = order.m_Food.m_FoodTexture;
					order.m_DeliveryIndicator.m_FoodImage.transform.localScale = Vector3.one;
					order.m_DeliveryIndicator.f_EdgeBuffer = 51.5f;
					order.m_DeliveryIndicator.m_targetIconScale = Vector3.one;
				}
			}
			else
			{
				if (order.m_DeliveryIndicator != null)
				{
					Destroy(order.m_DeliveryIndicator.m_FoodImage);
					Destroy(order.m_DeliveryIndicator.m_IconImage);
					Destroy(order.m_DeliveryIndicator);
					order.m_DeliveryIndicator = null;
				}
			}
		}
	}

	void Update()
	{
		//TEMP
		if(tempSpawnButton)
		{
			NewOrder();
			tempSpawnButton = false;
		}

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

		// Check Delivery Indicators
		CheckIndicators();
	}


}
