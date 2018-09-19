using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlaySound : MonoBehaviour {

	public AudioClip clip;
	public float interactDelay = 0;

	//Runs when the player moves into this trigger
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			//Run the function "PlaySound" after [interactDelay] seconds
			Invoke("PlaySound", interactDelay);
		}
	}

	private void PlaySound()
	{
		AudioSource.PlayClipAtPoint (clip, transform.position);
	}

}
