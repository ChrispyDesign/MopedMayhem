// Main Author - Christoper Bowles
//	Alterations by -
//
// Date last worked on 29/09/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInventory : MonoBehaviour {

	public Text leftText;
	public Text rightText;

	public Food m_DefaultFood;
	public Food m_LeftFood;		// Public for testing
	public Food m_RightFood;    // Public for testing

	// Use this for initialization
	void Awake ()
	{
		m_LeftFood = m_DefaultFood;
		m_RightFood = m_DefaultFood;
	}

	public bool ContainsFoodOfName(string name)
	{
		// IF Left food OR right food has name of food given
		if (m_LeftFood.m_sFoodName == name || m_RightFood.m_sFoodName == name)
		{
			return true;
		}
		// ELSE return false
		return false;
	}

	public void RemoveFoodByName(string name)
	{
		// IF Left food has name of food to be removed
		if (m_LeftFood.m_sFoodName == name)
		{
			// Set held food to default
			m_LeftFood = m_DefaultFood;
			leftText.text = "Nothing";
		}
		// ELSE IF Right food has name of food to be removed
		else if (m_RightFood.m_sFoodName == name)
		{
			// Set held food to default
			m_RightFood = m_DefaultFood;
			rightText.text = "Nothing";
		}		
	}

	public bool AddFood(Food food)
	{
		// IF Left food slot has default
		if (m_LeftFood == m_DefaultFood)
		{
			// Set held food to new food and return true
			m_LeftFood = food;
			leftText.text = food.m_sFoodName;
			return true;
		}

		// IF Right food slot has default
		if (m_RightFood == m_DefaultFood)
		{
			// Set held food to new food and return true
			m_RightFood = food;
			rightText.text = food.m_sFoodName;
			return true;
		}

		// Failed to add food return false
		return false;
	}

	public void DropLeftFood()
	{
		// IF held food is not default
		if (m_LeftFood != m_DefaultFood)
		{
			// Drop food on road
			DropOnRoad(m_LeftFood);

			// Set held food to default
			m_LeftFood = m_DefaultFood;
			leftText.text = "Nothing";
		}
	}

	public void DropRightFood()
	{
		// IF held food is not default
		if (m_RightFood != m_DefaultFood)
		{
			// Drop food on road
			DropOnRoad(m_RightFood);

			// Set held food to default
			m_RightFood = m_DefaultFood;
			rightText.text = "Nothing";
		}
	}

	private void DropOnRoad(Food food)
	{
		// Create the dropped food prefab
		GameObject temp = Instantiate(food.m_FoodPrefab);

		// Add The dropped food component
		temp.AddComponent<DroppedFood>();

		// IF there is NO rigid body 
		if (!temp.GetComponent<Rigidbody>())
		{
			// Add a rigid body
			temp.AddComponent<Rigidbody>();
		}
	}
}
