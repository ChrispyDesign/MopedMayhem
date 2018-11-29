// Author - Tim Langford
// Last Modified - 29/11/18

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
	public GameObject m_MopedMayhemLogo; // the logo that spins
	private Vector3 m_LogoRotation; // the vector to rotate the logo
	public float m_LogoRotSpeed = 1; // the rotation speed of the logo
	
	// calls when the scene starts
	void Start()
	{
		m_LogoRotation.y = m_LogoRotSpeed; // starts the rotation
		LoadLevel(2); // calls the level load function
	}

	// LoadScene Function
	public void LoadLevel(int sceneIndex)
	{
		StartCoroutine(LoadAsynchronously(sceneIndex));
	}

	// Loading Asynchronously
	IEnumerator LoadAsynchronously(int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

		while(!operation.isDone)
		{
			Debug.Log(operation.progress);

			yield return null;
		}
	}
	private void LateUpdate()
	{
		m_MopedMayhemLogo.transform.Rotate(m_LogoRotation);
	}
}
