// Main Author - Tim Langford
//
// Date Last worked on ??/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
	/// <summary> 
	///------	List of things to do	------
	/// - needs references to other scripts
	/// + set up the game reset
	/// - set up game loops
	/// - find out what other functions will be needed
	/// </summary>
	
	public bool reloadScene = false;
	private bool paused = false;

	public GameObject pauseCanvas;
	// Use this for initialization
	void Start()
	{
		var findGameManager = FindObjectsOfType<GameManager>();
		if (findGameManager.Length > 1)
		{
			Debug.LogError("[Singleton] there is more then one GameManager in the Scene.");
		}
		pauseCanvas.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (reloadScene == true && paused == false)
		{
			RePlay();
		}

		if (Input.GetButtonDown("Pause"))
		{
			Pause();
		}
	}

	public void Sceneload(string scene)
	{
		SceneManager.LoadScene(scene);
	}

	public void GameLoop()
	{

	}

	public void Pause()
	{
		paused = !paused;
		if(paused == true)
		{
			Time.timeScale = 0;
			/// pause canvas.setactive = true
			pauseCanvas.SetActive(true);
		}
		else
		{
			Time.timeScale = 1;
			/// pause canvas.setactive = false
			pauseCanvas.SetActive(false);
		}
	}

	public void RePlay()
	{
		Sceneload(SceneManager.GetActiveScene().name);
	}
}
