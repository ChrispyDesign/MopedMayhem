using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

	public List<string> inventoryList = new List<string> ();

	public GameObject inventoryPanel;
	public Text inventoryText;

	//Add an item to your inventory
	public void AddItem(string itemName)
	{
		inventoryList.Add(itemName);
		UpdateInventory();
	}

	//Check if an item is in your inventory
	public bool CheckItem(string itemName)
	{
		if (itemName == "") 
		{
			return true;
		}
		return inventoryList.Contains (itemName);
	}

	//Checks to see if the player has pressed I to open the inventory
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.I)) 
		{
			UpdateInventory ();
			inventoryPanel.SetActive (!inventoryPanel.activeSelf);
		}
	}

	//Loop through all the items in your inventory and write them to screen
	private void UpdateInventory()
	{
		string inventoryString = "";

		foreach (string item in inventoryList) 
		{
			inventoryString += item + "\n";
		}

		inventoryText.text = inventoryString;
	}
}
