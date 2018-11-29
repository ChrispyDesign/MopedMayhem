// Main Author - Christoper Bowles
//	Alterations by -
//
// Date last worked on 29/09/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedFood : MonoBehaviour
{
	private OrderManager m_OrderManager;
	public Food m_Food;
	public bool m_bColliding;

	// Use this for initialization
	void Start ()
	{
		m_OrderManager = FindObjectOfType<OrderManager>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		var list = m_OrderManager.m_DroppedFoodList;
		if (collision.collider.CompareTag("Player"))
		{
			m_bColliding = true;
			list.Remove(this);
			list.Insert(0, this);
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			m_bColliding = false;
		}
	}

	public void Delete()
	{
		m_OrderManager.m_DroppedFoodList.Remove(this);
		gameObject.SetActive(false);
	}
}
