// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 01/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
	[HideInInspector]
	public GameObject m_ParentObject;
	[HideInInspector]
	public BaseFSM m_ParentFSM;

	public void OnStart()
	{
		Setup();
	}

	protected abstract void Setup();

	// Update is called once per frame
	public abstract void UpdateState();

	public abstract void OnEnd();
}
