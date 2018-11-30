// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 21/11/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDisabler : MonoBehaviour {

	// Use this for initialization
	void Awake ()
	{
		gameObject.GetComponent<MeshRenderer>().enabled = false;
	}
}
