using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTeleportSelf : MonoBehaviour {

	public Transform transformToTeleportObjectTo;

	//Runs when the player moves into this trigger
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			if (!transformToTeleportObjectTo) {
				Debug.LogWarning ("You have not assigned a reference for this teleport script");
			}
			//Run the function "DeactivateObject" after [interactDelay] seconds
			other.transform.position = transformToTeleportObjectTo.position;
			other.transform.rotation = transformToTeleportObjectTo.rotation;
		}
	}

	//Draws a line from the start to the end point when this trigger is selected
	void OnDrawGizmosSelected()
	{
		if (transformToTeleportObjectTo) {
			Debug.DrawLine (transform.position, transformToTeleportObjectTo.transform.position);
		}
	}
}
