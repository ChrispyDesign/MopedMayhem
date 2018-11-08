// Main Author - Tim Langford
//
// Date Last worked on ??/10/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
    private bool hasLost = false;

	public GameObject m_PauseCanvas;
    public _TestHighScore Score;
    public _ScoreControl sController; 
	public GameObject m_GameOverCanvas;

	public int m_iTimeLimit;
	private int m_fStartTime;
	private int Min, Sec;
	private float fSeconds;
    public Text ScoreTxt;

	public GameObject MinuteBox, SecondBox;

    private void Awake()
    {
        sController = FindObjectOfType<_ScoreControl>();
        Score = FindObjectOfType<_TestHighScore>();
        hasLost = false;
    }

    // Use this for initialization
    void Start()
	{
		var findGameManager = FindObjectsOfType<GameManager>();
		if (findGameManager.Length > 1)
		{
			Debug.LogError("[Singleton] there is more then one GameManager in the Scene.");
		}

		Time.timeScale = 1;

		Min = m_iTimeLimit;
		Sec = 1;
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

        GameLoop();
    }

	public void Sceneload(string scene)
	{
		SceneManager.LoadScene(scene);
	}

	public void GameLoop()
	{       
       fSeconds += Time.deltaTime;
       if (fSeconds > 1)
       {
           Sec--;
           fSeconds--;
       }
       if (Sec < 0)
       {
           Min--;
           Sec = 59;
       }
       if (Min < 0)
       {
           Min = 0;
       }
       if (Min == 0 && Sec == 0)
       {            
            EndGame();
       }
       if (Sec <= 9)
       {
           SecondBox.GetComponent<Text>().text = "0" + Sec;
       }
       else
       {
           SecondBox.GetComponent<Text>().text = "" + Sec;
       }

       MinuteBox.GetComponent<Text>().text = Min + ":";
	}

	public void Pause()
	{
		paused = !paused;
		if(paused == true)
		{
			Time.timeScale = 0;
			/// pause canvas.setactive = true
			m_PauseCanvas.SetActive(true);
		}
		else
		{
			Time.timeScale = 1;
			/// pause canvas.setactive = false
			m_PauseCanvas.SetActive(false);
		}
	}

    public void EndGame()
    {
        Time.timeScale = 0f;
        m_GameOverCanvas.SetActive(true);
    }

	public void RePlay()
	{
		Sceneload(SceneManager.GetActiveScene().name);
		Time.timeScale = 1;
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
