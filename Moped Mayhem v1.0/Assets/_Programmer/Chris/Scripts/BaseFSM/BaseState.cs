using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BaseState : MonoBehaviour
{
	[HideInInspector]
	public GameObject m_ParentObject;
	[HideInInspector]
	public BaseFSM m_ParentFSM;

	// Use this for initialization
	void Start()
	{
		Setup();
	}

	public void OnStart()
	{
		Setup();
	}

	protected abstract void Setup();

	// Update is called once per frame
	public abstract void UpdateState();

	public abstract void OnEnd();
}
