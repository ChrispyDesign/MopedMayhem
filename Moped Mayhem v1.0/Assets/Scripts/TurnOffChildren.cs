// Main Author - Christopher POERMANDYA
//	Alterations by - 
//
// Date last worked on 29/11/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffChildren : MonoBehaviour {

    public GameObject thisGO;

	// Use this for initialization
	void Start () {
        thisGO = this.gameObject;
        thisGO.transform.GetChild(0).gameObject.SetActive(false);
	}
	
}
