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
