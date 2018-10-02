// Main Author - Christoper Bowles
//	Alterations by -
//
// Date last worked on 29/09/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{

    public Color m_OrderColor;
	public DeliveryDropoff m_DropOffZone;
    public Food m_Food;
	public float m_fStartTime;
	public float m_fOrderExiryTime;

	[HideInInspector]
	public OrderManager m_OrderManager;

	public void Success()
	{
		m_OrderManager.OrderSuccess(this);
	}
}
