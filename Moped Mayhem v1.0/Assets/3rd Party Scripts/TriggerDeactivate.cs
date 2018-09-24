using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TriggerDisplay))]
public class TriggerDeactivate : MonoBehaviour {

	public GameObject objectToDeactivate;
	public float interactDelay = 0;

	//Runs when the player moves into this trigger
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			//Run the function "DeactivateObject" after [interactDelay] seconds
			Invoke ("DeactivateObject", interactDelay);
		}
	}

	//Deactivates an object
	private void DeactivateObject()
	{
		objectToDeactivate.SetActive (false);
	}
}
