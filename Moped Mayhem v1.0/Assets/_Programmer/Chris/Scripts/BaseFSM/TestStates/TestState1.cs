using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestState1 : BaseState
{
	//[HideInInspector]
	public bool bStarted;

	protected override void Setup()
	{
		bStarted = true;
	}

	// Update is called once per frame
	public override void UpdateState ()
	{
		if (m_ParentObject.transform.position.y < 50)
		{
			m_ParentObject.transform.position += Vector3.up;
		}
		else
		{
			m_ParentFSM.ChangeState("TestState2");
		}
	}

	public override void OnEnd()
	{
		bStarted = false;
	}
}
