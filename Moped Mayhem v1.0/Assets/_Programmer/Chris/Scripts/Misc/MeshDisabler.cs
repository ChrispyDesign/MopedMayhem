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
