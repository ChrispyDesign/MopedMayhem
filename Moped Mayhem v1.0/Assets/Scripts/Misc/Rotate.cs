// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 30/11/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public Vector3 m_Rotation;
		
	// Update is called once per frame
	void Update ()
	{
		var rot = transform.rotation;
		rot.eulerAngles += m_Rotation * Time.deltaTime;

		transform.rotation = rot;
	}
}
