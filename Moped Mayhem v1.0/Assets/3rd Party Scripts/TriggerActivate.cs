using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TriggerDisplay))]
public class TriggerActivate : MonoBehaviour {

	public GameObject objectToActivate;
	public float interactDelay = 0;

	//Runs when the player moves into this trigger
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			//Run the function "ActivateObject" after [interactDelay] seconds
			Invoke("ActivateObject", interactDelay);
		}
	}

		//Deactivates an object
		private void ActivateObject()
	{
		objectToActivate.SetActive (true);
	}
}
