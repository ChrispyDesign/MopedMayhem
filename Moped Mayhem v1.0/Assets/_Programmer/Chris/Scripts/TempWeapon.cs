using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWeapon : MonoBehaviour {

	public TempHeart hearts;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			hearts.TakeDamage();
		}
	}
}
