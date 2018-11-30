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
	public Text score;

    public AudioSource TicketComplete;

	public Texture m_IconOnScreen;
	public TicketManager m_TicketManager;
	public PlayerInventory m_PlayerInventory;
    public AudioSource DeliveryLost;

    public Food[] m_Foods;
	private List<string> m_FoodNames = new List<string>();
	private Dictionary<string, int> m_FoodsIndexByName = new Dictionary<string, int>();
	private int[] m_nActiveFoodCount;
	private List<Food> m_InactiveFoods = new List<Food>();
	
	public float m_fMinSpawnTime = 5.0f;
	public float m_fMaxSpawnTime = 10.0f;
	private float m_fNextSpawnTime;

	public int m_nMaxOrders = 7;

	public float m_fOrderExpiryTime = 10.0f;

	[Header("Rewards (LOW to HI)")]
	public int m_nReward_00;
	public int m_nReward_25;
	public int m_nReward_50;
	public int m_nReward_75;

	[Header("Fail Cost")]
	public int m_nFailCost;

	[Header("DONT ADD ANYTHING TO THESE")]
	public List<DeliveryDropoff> m_DropOffZones = new List<DeliveryDropoff>();
	public List<DeliveryPickup> m_PickUpZones = new List<DeliveryPickup>();

	public DeliveryDropoff m_CurrentDropOffZone;
	public DeliveryPickup m_CurrentPickUpZone;

	public List<DroppedFood> m_DroppedFoodList = new List<DroppedFood>();

	private List<Order> m_ActiveOrders = new List<Order>();
	private List<Order> m_InActiveOrders = new List<Order>();

	public float m_fIndicatorScale = 0.6f;
	public float m_fIndicatorEdgeBuffer = 51.5f;

	private PlayerParticles m_PlayerParticles;

    [Header("TUTORIAL")]
    public bool m_bTutorial = false;
    public DeliveryPickup m_TutRestaurant;
    public DeliveryDropoff m_TutDropOff;

	// Use this for initialization
	void Start ()
	{
		m_PlayerParticles = m_PlayerInventory.gameObject.GetComponent<PlayerParticles>();

		// FOR each food in m_Foods
		for (int i = 0; i < m_Foods.Length; ++i)
		{
			// Add name of food to foodNames
			m_FoodNames.Add(m_Foods[i].m_sFoodName);

			// Add index to dictionary with name as key
			m_FoodsIndexByName.Add(m_Foods[i].m_sFoodName, i);

			// Add to inactive foods
			m_InactiveFoods.Add(m_Foods[i]);
		}

		// Initialise active food count
		m_nActiveFoodCount = new int[m_Foods.Length];
		
		// Set Next Spawn Time
		m_fNextSpawnTime = Time.time/* + Random.Range(m_fMinSpawnTime, m_fMaxSpawnTime)*/;
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
		// IF no available foods
		if (m_InactiveFoods.Count == 0)
		{
			Debug.LogWarning("No available food");
			return;
		}

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
		newOrder.m_fStartTime = Time.time;
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
		int nRandom = Random.Range(0, m_InactiveFoods.Count);

		var food = m_InactiveFoods[nRandom];

		m_InactiveFoods.RemoveAt(nRandom);
		
		return food;
	}

	public void OrderSuccess(Order order)
	{
		m_PlayerParticles.Play(m_PlayerParticles.m_GainMoney);

		// Specific Success Stuff
		int nScore = int.Parse(score.text);

		float fQuart = m_fOrderExpiryTime / 4;
		float fRemaining = (Time.time - order.m_fStartTime);

		if (fRemaining < fQuart)
		{
			nScore += m_nReward_75;
		}
		else if (fRemaining < fQuart * 2)
		{
			nScore += m_nReward_50;
		}
		else if (fRemaining < fQuart * 3)
		{
			nScore += m_nReward_25;
		}
		else
		{
			nScore += m_nReward_00;
		}


		score.text = nScore.ToString();
		
		if (TicketComplete)
		{
			TicketComplete.Play();
		}
		else
		{
			Debug.LogWarning("Connect TicketComplete you knob");
		}

		// Run Order Complete
		OrderComplete(order);
	}

	public void OrderFailed(Order order)
	{
		if (m_PlayerInventory.ContainsFoodOfName(order.m_Food.m_sFoodName))
		{
			var particle = m_PlayerParticles.m_DropoffBurger;

			switch (order.m_Food.m_sFoodName)
			{
				case "Burger":
					particle = m_PlayerParticles.m_DropoffBurger;
					break;
				case "Chinese":
					particle = m_PlayerParticles.m_DropoffChinese;
					break;
				case "Sushi":
					particle = m_PlayerParticles.m_DropoffSushi;
					break;
				case "Doughnuts":
					particle = m_PlayerParticles.m_DropoffDoughnuts;
					break;
				default:
					Debug.LogError("Wrong particle name, " + name);
					break;
			}

			m_PlayerParticles.Play(particle);
		}
		m_PlayerParticles.Play(m_PlayerParticles.m_LoseMoney);

		// Specific Failure Stuff
		int nScore = int.Parse(score.text);
		nScore -= m_nFailCost;
		score.text = nScore.ToString();

		if (DeliveryLost)
		{
			DeliveryLost.Play();
		}
		else
		{
			Debug.LogWarning("Connect DeliveryLost you knob");
		}

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

		m_InactiveFoods.Add(m_Foods[nIndex]);

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

		// Destroy Delivery Indicator, if it exists
		if (order.m_DeliveryIndicator != null)
		{
			Destroy(order.m_DeliveryIndicator.m_IconImage.gameObject);
			Destroy(order.m_DeliveryIndicator.m_FoodImage.gameObject);
			Destroy(order.m_DeliveryIndicator);
			order.m_DeliveryIndicator = null;
		}
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
				order.m_DropOffZone.gameObject.SetActive(true);
				if (order.m_DeliveryIndicator == null)
				{
					order.m_DeliveryIndicator = order.m_DropOffZone.gameObject.AddComponent<_BDeliveryIndicator>();

					if (order.m_DeliveryIndicator.m_IconImage == null)
					{
						Debug.LogError("Delivery Indicator Not Instantiated First time round");
						order.m_DeliveryIndicator.InstainateTargetIcon();
					}

					order.m_DeliveryIndicator.m_TargetIconOnScreen = m_IconOnScreen;
					order.m_DeliveryIndicator.m_TargetIconForFood = order.m_Food.m_FoodTexture;
					order.m_DeliveryIndicator.m_IconImage.texture = m_IconOnScreen;
					order.m_DeliveryIndicator.m_IconImage.color = order.m_Food.m_TicketColor;
					order.m_DeliveryIndicator.m_IconImage.transform.localScale = Vector3.one * m_fIndicatorScale;
					order.m_DeliveryIndicator.m_FoodImage.texture = order.m_Food.m_FoodTexture;
					order.m_DeliveryIndicator.m_FoodImage.transform.localScale = Vector3.one * m_fIndicatorScale;
					order.m_DeliveryIndicator.f_EdgeBuffer = m_fIndicatorEdgeBuffer;
					order.m_DeliveryIndicator.m_targetIconScale = Vector3.one * m_fIndicatorScale;
				}
			}
			else
			{
				if (order.m_DeliveryIndicator != null)
				{
					Destroy(order.m_DeliveryIndicator.m_IconImage.gameObject);
					Destroy(order.m_DeliveryIndicator.m_FoodImage.gameObject);
					Destroy(order.m_DeliveryIndicator);
					order.m_DeliveryIndicator = null;
				}
			}
		}
	}

    private void Tutorial()
    {
        // Get Random Food
        Food food = m_TutRestaurant.m_RestaurantFood;
        m_InactiveFoods.RemoveAt(m_FoodsIndexByName[food.m_sFoodName]);

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


        // Get Tutorial DropOff Point
        newOrder.m_DropOffZone = m_TutDropOff;

        // Set Order variables
        newOrder.m_OrderManager = this;
        newOrder.m_Food = Instantiate(food);
        newOrder.m_fStartTime = Time.time;
        newOrder.m_fOrderExiryTime = m_fOrderExpiryTime;

        // Add Order to active order list
        m_ActiveOrders.Add(newOrder);

        // Activate Pickup zone
        ActivatePickup(newOrder.m_Food);

        // Activate Dropoff zone
        //newOrder.m_DropOffZone.Activate(newOrder);

        // UI STUFF

        m_TicketManager.ActivateTicket(newOrder);
    }

	void Update()
	{
		float fCurrentTime = Time.time;

        if (m_bTutorial)
        {
            Tutorial();
            m_bTutorial = false;

            // Get new random time for next spawn
            m_fNextSpawnTime = fCurrentTime + Random.Range(m_fMinSpawnTime, m_fMaxSpawnTime);
        }

		// Check for timed-out/failed orders
		int iter = 0;
		while (iter < m_ActiveOrders.Count)
		{
			// Get current order
			Order order = m_ActiveOrders[iter];

			if (m_PlayerInventory.ContainsFoodOfName(order.m_Food.m_sFoodName))
			{
				order.m_DropOffZone.Activate(order);
			}
			else
			{
				order.m_DropOffZone.Deactivate();
			}

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
