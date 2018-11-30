// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 23/11/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLock : MonoBehaviour
{
	void FixedUpdate ()
	{
		var rot = transform.rotation;
		var euler = rot.eulerAngles;

		euler.x = 0;
		euler.z = 0;

		rot.eulerAngles = euler;
		transform.rotation = rot;
	}
}
