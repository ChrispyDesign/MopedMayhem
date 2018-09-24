using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatMessage : MonoBehaviour {

	public float distanceToTrigger = 5;
	public float timeToTrigger = 1;
	[Range(0.01f, 0.2f)]
	public float accuracy = 0.05f;
	public bool activateOnce = true;
	private float timer;

	public string messageToDisplay = "You looked at me!";
	public float messageDuration = 2;

	public string requiresItem = "";

	// Update is called once per frame
	void Update () {

		if (!GameObject.FindObjectOfType<InventoryController> ().CheckItem (requiresItem)) {
			return;
		}

		float distanceToPlayer = Vector3.Distance (Camera.main.transform.position, transform.position);

		if(distanceToPlayer > distanceToTrigger)
		{
			timer = 0;
			return;
		}

		//Get the vector from the players camera forward
		Vector3 playerForward = Camera.main.transform.forward;

		//Get vectory from object to the player
		Vector3 objectToPlayer = Vector3.Normalize(transform.position - Camera.main.transform.position);

		//Draw debuf rays of both vectors
		Debug.DrawRay(Camera.main.transform.position, playerForward * distanceToTrigger);
		Debug.DrawRay(Camera.main.transform.position, objectToPlayer * distanceToTrigger, Color.yellow);

		//If both vectors are alligned you will get a Dot Product of 1
		if (Vector3.Dot(playerForward, objectToPlayer) < 1 - accuracy)
		{
			timer = 0;
			return; 
		}
		timer += Time.deltaTime;

		if (timer >= timeToTrigger)
		{
			//Trigger the event you want triggered
			//Change this line to change the thing you want to trigger. Play Sound, pick up, etc.
			GameObject.FindObjectOfType<UIController>().
			ShowMessage(messageToDisplay,messageDuration);
			timer = 0;
			//Deactivate this script once run
			if (activateOnce)
			{
				this.enabled = false;
			}
		}
	}
}
