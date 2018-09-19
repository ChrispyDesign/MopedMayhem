using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TriggerDisplay))]
public class TriggerMessage : MonoBehaviour {

	public string messageToShow = "Default Message";
	public float messageDuration = 3;

	public string requiresItem = "";

	//Runs when the player moves into this trigger
	void OnTriggerEnter(Collider other)
	{
		//If this trigger requires an item then check to see if the player has that item
		if (!GameObject.FindObjectOfType<InventoryController> ().CheckItem (requiresItem)) {
			//If they don't, stop running this funtion
			return;
		}

		//Checks if the tag of the object entered is "Player"
		if (other.tag == "Player") {
			GameObject.FindObjectOfType<UIController> ().
				ShowMessage (messageToShow, messageDuration);
		}
	}
}
