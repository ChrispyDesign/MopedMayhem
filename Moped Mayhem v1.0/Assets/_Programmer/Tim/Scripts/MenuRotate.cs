// Author - Tim Langford
// Last Modified - 29/11/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRotate : MonoBehaviour
{
	private Vector3 MenuRot; // the rotation of the camera to spin around the scene
	public float rotSpeed; // the speed the rotation of the camera is

	// Use this for initialization
	void Start () {
		MenuRot.y = rotSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(MenuRot);
	}
}
