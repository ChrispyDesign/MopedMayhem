using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFSM : MonoBehaviour {

	public GameObject m_ParentObject;
	public List<BaseState> m_States;
	public BaseState m_StartState;
	private BaseState m_CurrentState;

	//------------------------------------------------------------
	// Start
	//		Runs the setup
	//------------------------------------------------------------
	void Start()
	{
		Setup();
	}

	//------------------------------------------------------------
	// Awake
	//		Re-runs the setup
	//------------------------------------------------------------
	void Awake ()
	{
		Setup();
	}

	//------------------------------------------------------------
	// Setup
	//		Gets currentState from list, 
	//		deactivates all other states
	//------------------------------------------------------------
	void Setup()
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
			}
			// ELSE not starting state
			else
			{
				// Disable the state
				m_CurrentState.OnEnd();
				state.enabled = false;
			}
		}
	}

	//------------------------------------------------------------
	// Update
	//		Updates the currentState 
	//------------------------------------------------------------
	void Update()
	{
		m_CurrentState.UpdateState();
	}

	//------------------------------------------------------------
	// ChangeState
	//		Ends current state and changes to new state
	//
	//	var
	//		string - sNewStateName
	//			name of new String
	//------------------------------------------------------------
	public void ChangeState(string sNewStateName)
	{
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
		Debug.Log(message, m_ParentObject);
	}

}
