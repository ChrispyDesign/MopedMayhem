// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 08/11/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFSM : MonoBehaviour {

	public GameObject m_ParentObject;
	public List<BaseState> m_States;
	public BaseState m_StartState;
	protected BaseState m_CurrentState;
	protected int nChangeStateCount;

	//------------------------------------------------------------
	// Start
	//		Runs the setup
	//------------------------------------------------------------
	protected virtual void Start()
	{
		Setup();
	}

	//------------------------------------------------------------
	// Awake
	//		Re-runs the setup
	//------------------------------------------------------------
	protected virtual void Awake ()
	{
		Setup();
	}

	//------------------------------------------------------------
	// Setup
	//		Gets currentState from list, 
	//		deactivates all other states
	//------------------------------------------------------------
	protected virtual void Setup()
	{
		// For Each state in state list
		foreach (BaseState state in m_States)
		{
			// Set the states Parent Object and FSM
			state.m_ParentObject = m_ParentObject;
			state.m_ParentFSM = this;

			// IF state is starting state
			if (state.GetType() == m_StartState.GetType())
			{
				// Store as current state
				m_CurrentState = state;
				m_CurrentState.OnStart();
			}
			// ELSE not starting state
			else
			{
				// Disable the state
				state.OnEnd();
				state.enabled = false;
			}
		}
	}

	//------------------------------------------------------------
	// FixedUpdate
	//		Updates the currentState 
	//------------------------------------------------------------
	protected virtual void FixedUpdate()
	{
		m_CurrentState.UpdateState();
	}

	//------------------------------------------------------------
	// ChangeState
	//		Ends current state and changes to new state
	//
	//	var
	//		string - sNewStateName
	//			name of new State
	//------------------------------------------------------------
	public void ChangeState(string sNewStateName)
	{
		nChangeStateCount++;

		// For each state in state list
		foreach (BaseState state in m_States)
		{
			// IF state is the new state
			if (state.GetType().ToString() == sNewStateName)
			{
				// End Current State and disable
				m_CurrentState.OnEnd();
				m_CurrentState.enabled = false;

				// Set New state as current and enable
				m_CurrentState = state;
				m_CurrentState.enabled = true;
				m_CurrentState.OnStart();

				// Found new state return to avoid rest of foreach loop
				return;
			}
		}

		// Log Failure to debug console
		string message = "Change state failed, current state: " + m_CurrentState.GetType();
		message += " Intended State: " + sNewStateName;
		Debug.LogError(message, m_ParentObject);
	}

}
