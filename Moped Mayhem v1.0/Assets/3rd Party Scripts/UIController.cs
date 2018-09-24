using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text messageText;
	public GameObject messagePanel;
	private float displayTimer;
	private float displayLength; 
	private bool isShowingMessage = false;

	//Function that gets callled from other scripts, it gets passed a
	//string (what to say) and a float (how long to say it)
	public void ShowMessage(string message, float duration = 3)
	{
		//Set the messagePanel active
		messagePanel.SetActive (true);
		//Change the text to the message that was passed to this function
		messageText.text = message;
		//Set a bool saying that a message is currently being shown
		isShowingMessage = true;
		//Set a timer to remove the message after a set amount of time
		displayLength = duration;
		displayTimer = Time.time;
	}

	//Update is called once per frame
	void Update(){
		//If the script is currently showing a message
		if (isShowingMessage) {
			//Check the amount of time that has passed
			if (Time.time - displayTimer > displayLength) {
				//Deactivate the panel
				messagePanel.SetActive (false);
				isShowingMessage = false;
			}
		}
	}

}
