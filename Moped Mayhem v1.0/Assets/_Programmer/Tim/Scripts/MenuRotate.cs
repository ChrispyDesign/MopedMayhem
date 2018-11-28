using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRotate : MonoBehaviour {

	private Vector3 MenuRot;
	public float rotSpeed;

	// Use this for initialization
	void Start () {
		MenuRot.y = rotSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(MenuRot);
	}
}
