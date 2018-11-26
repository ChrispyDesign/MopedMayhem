using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisibility : MonoBehaviour {

	private Camera m_MainCamera;

	public int m_nBuildingLayer = 8;

	public Shader m_GlowShader;
	private Shader m_NormalShader;

	// Use this for initialization
	void Awake ()
	{
		m_MainCamera = Camera.main;

		m_NormalShader = GetComponentInChildren<MeshRenderer>().material.shader;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// IF View Obstructed
		if (ViewObstructed())
		{
			// Use Glow Shader
			var renderers = GetComponentsInChildren<MeshRenderer>();
			foreach (var renderer in renderers)
			{
				renderer.material.shader = m_GlowShader;
			}

		}
		else
		{
			// Use Normal Shader
			var renderers = GetComponentsInChildren<MeshRenderer>();
			foreach (var renderer in renderers)
			{
				renderer.material.shader = m_NormalShader;
			}
		}
	}

	private bool ViewObstructed()
	{
		Vector3 v3CamPos = m_MainCamera.transform.position;

		Vector3 direction = transform.position - v3CamPos;
		Ray ray = new Ray(v3CamPos, direction);

		Debug.DrawLine(transform.position, v3CamPos);

		// This is a bitmask that makes it so we only check the building layer 
		int layerMask = 1 << m_nBuildingLayer;

		// Check to see if we hit a building
		if (Physics.Raycast(ray, direction.magnitude, layerMask))
		{
			// View Obstructed
			return true;
		}

		// View Not Obstructed
		return false;
	}
}
