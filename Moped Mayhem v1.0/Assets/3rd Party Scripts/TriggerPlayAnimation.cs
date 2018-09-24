using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayAnimation : MonoBehaviour {

	public Animator animator;
	public float interactDelay = 0;

	//Runs when the player moves into this trigger
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			//Run the function "PlayAnimation" after [interactDelay] seconds
			Invoke ("PlayAnimation", interactDelay);
		}
	}

	private void PlayAnimation()
	{
		animator.SetTrigger("play");
	}
}
