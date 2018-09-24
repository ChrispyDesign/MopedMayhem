using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TriggerDisplay))]
public class TriggerTeleportObject : MonoBehaviour {

	public GameObject objectToTeleport;
	public Transform transformToTeleportObjectTo;
	public float teleportDelay = 0;

	//Runs when the player moves into this trigger
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			//Run the function "TeleportObject" after [interactDelay] seconds
			Invoke("TeleportObject", teleportDelay);
		}
	}

	//Moves an object from one point to another
	private void TeleportObject()
	{
		if (!transformToTeleportObjectTo || !objectToTeleport) {
			Debug.LogWarning ("You have not assigned a reference for this teleport script");
		}

		objectToTeleport.transform.position = transformToTeleportObjectTo.position;
		objectToTeleport.transform.rotation = transformToTeleportObjectTo.rotation;
	}

	//Draws a line from the start to the end point when this trigger is selected
	void OnDrawGizmosSelected()
	{
		if (transformToTeleportObjectTo && objectToTeleport) {
			Debug.DrawLine (transformToTeleportObjectTo.position, objectToTeleport.transform.position);
		}
	}
}
