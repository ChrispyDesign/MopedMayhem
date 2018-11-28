using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

	// loadBar
	public GameObject m_MopedMayhemLogo;

	private Vector3 m_LogoRotation;
	
	void Start()
	{
		m_LogoRotation.y = 1;
		//LoadLevel(2);
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

		m_MopedMayhemLogo.SetActive(true);

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
