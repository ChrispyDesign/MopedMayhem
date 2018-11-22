// Main Author - Christoper Bowles
//	Alterations by -
//
// Date last worked on 29/09/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInventory : MonoBehaviour {

	public RawImage m_LeftImage;
	public RawImage m_RightImage;

	public Food m_DefaultFood;
	public Food m_LeftFood;		// Public for testing
	public Food m_RightFood;    // Public for testing

	private Color m_DefaultBackColour;

	private RawImage m_LeftBackImage;
	private RawImage m_RightBackImage;

	// Use this for initialization
	void Awake ()
	{
		m_LeftFood = m_DefaultFood;
		m_RightFood = m_DefaultFood;

		m_LeftBackImage = m_LeftImage.transform.parent.gameObject.GetComponent<RawImage>();
		m_RightBackImage = m_RightImage.transform.parent.gameObject.GetComponent<RawImage>();

		if (m_LeftBackImage)
		{
			m_DefaultBackColour = m_LeftBackImage.material.color;
		}
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
			m_LeftImage.texture = m_DefaultFood.m_FoodTexture;

			var color = m_LeftImage.color;
			color.a = 0;
			m_LeftImage.color = color;

			if (m_LeftBackImage)
			{
				m_LeftBackImage.color = m_DefaultBackColour;
			}
		}
		// ELSE IF Right food has name of food to be removed
		else if (m_RightFood.m_sFoodName == name)
		{
			// Set held food to default
			m_RightFood = m_DefaultFood;
			m_RightImage.texture = m_DefaultFood.m_FoodTexture;

			var color = m_RightImage.color;
			color.a = 0;
			m_RightImage.color = color;

			if (m_RightBackImage)
			{
				m_RightBackImage.color = m_DefaultBackColour;
			}
		}
	}		

	public bool AddFood(Food food)
	{
		// IF Left food slot has default
		if (m_LeftFood == m_DefaultFood)
		{
			// Set held food to new food and return true
			m_LeftFood = food;
			m_LeftImage.texture = food.m_FoodTexture;

			var colorFood = m_LeftImage.color;
			colorFood.a = 255;
			m_LeftImage.color = colorFood;

			if (m_LeftBackImage)
			{
				var color = food.m_TicketColor;
				color.a = m_DefaultBackColour.a;
				m_LeftBackImage.color = color;
			}
			return true;
		}

		// IF Right food slot has default
		if (m_RightFood == m_DefaultFood)
		{
			// Set held food to new food and return true
			m_RightFood = food;
			m_RightImage.texture = food.m_FoodTexture;

			var colorFood = m_RightImage.color;
			colorFood.a = 255;
			m_RightImage.color = colorFood;

			if (m_RightBackImage)
			{
				var color = food.m_TicketColor;
				color.a = m_DefaultBackColour.a;
				m_RightBackImage.color = color;

			}
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
			m_LeftImage.texture = m_DefaultFood.m_FoodTexture;
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
			m_RightImage.texture = m_DefaultFood.m_FoodTexture;
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
