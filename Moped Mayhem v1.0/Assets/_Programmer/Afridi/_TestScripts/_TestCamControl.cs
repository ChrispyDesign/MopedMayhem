using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestCamControl : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;
	public GameObject PivotPoint;
	public GameObject Player;
	private Quaternion offset;

	public float x, z;

    private float yaw = 0.0f;

	private void Start()
	{
		x = 0.0f;
		z = 0.0f;
	}

	void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");

        PivotPoint.transform.eulerAngles = new Vector3(x, yaw, z);

		offset = Player.transform.rotation * PivotPoint.transform.rotation;

		PivotPoint.transform.rotation *= offset;
    }
}
