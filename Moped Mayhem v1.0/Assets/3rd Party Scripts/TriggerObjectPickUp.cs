using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TriggerDisplay))]
public class TriggerObjectPickUp : MonoBehaviour {

	public string objectName = "This thing";

	//Runs when the player moves into this trigger
	void OnTriggerEnter(Collider other)
	{
		//Checks if the tag of the object that enters is "Player"
		if (other.tag =="Player")
		{
			GameObject.FindObjectOfType<UIController> ().
				ShowMessage ("You have picked up a " + objectName, 2);
			GameObject.FindObjectOfType<InventoryController> ().AddItem (objectName);
			gameObject.SetActive (false);
		}
	}

}
