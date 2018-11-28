using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class V2MenuManager1 : MonoBehaviour {

	public GameObject MainMenu;
	public GameObject PlayButton;
	public GameObject QuitButton;
	public GameObject OptionsButton;
	public GameObject OptionsBackButton;
	public GameObject LeaderButton;
	public GameObject LeaderBackButton;

	public _TestHighScore h_Scores;
	public GameObject LeaderBoardScreen;
	public GameObject OptionsScreen;
	public GameObject SoundScreen;

	public Text Score_1;
	public Text Score_2;
	public Text Score_3;
	public Text Score_4;
	public Text Score_5;

	public Text TimeScore_1;
	public Text TimeScore_2;
	public Text TimeScore_3;
	public Text TimeScore_4;
	public Text TimeScore_5;

	public GameObject CurrentSelec;
	public Button CurrentButton;
	private int m_CurrentSelectedNum;

	void Awake()
	{
		h_Scores = FindObjectOfType<_TestHighScore>();
		m_CurrentSelectedNum = 1;
		CurrentSelec = PlayButton;
		CurrentButton = CurrentSelec.GetComponent<Button>();
	}

	// Update is called once per frame
	void Update()
	{
		float v = Input.GetAxis("Vertical");
		float h = Input.GetAxis("Horizontal");

		if (v > 0.1)
		{
			if (m_CurrentSelectedNum == 1)
			{
				m_CurrentSelectedNum = 4;
			}
			else
			{
				m_CurrentSelectedNum--;
			}
		}
		else if (v < -0.1)
		{
			if (m_CurrentSelectedNum == 4)
			{
				m_CurrentSelectedNum = 1;
			}
			else
			{
				m_CurrentSelectedNum++;
			}
		}

		switch (m_CurrentSelectedNum)
		{
			case 1:
				CurrentSelec = PlayButton;
				break;
			case 2:
				CurrentSelec = OptionsButton;
				break;
			case 3:
				CurrentSelec = LeaderButton;
				break;
			case 4:
				CurrentSelec = QuitButton;
				break;
		}

		if (Input.GetButtonDown("Fire1"))
		{
			if (CurrentSelec == PlayButton)
			{
				PlayGame();
			}
			else if (CurrentSelec == LeaderButton)
			{
				// Opens the highscores screen
				HighScoreStore();
				CurrentSelec = LeaderBackButton;
			}
			else if (CurrentSelec == LeaderBackButton)
			{
				// Closes the highscores screen
				CurrentSelec = LeaderButton;
				LeaderBoardScreen.SetActive(false);
				MainMenu.SetActive(true);
			}
			else if (CurrentSelec == OptionsButton)
			{
				OptionsScreen.SetActive(true);
				MainMenu.SetActive(false);
				//Option Included Stuff
				/*Sound (Music, Effects), Resolution, Invert Controls?, Customise Controls? or Schemes?, Mutator Settings*/
			}
			else if (CurrentSelec == OptionsBackButton)
			{
				CurrentSelec = OptionsButton;
				OptionsScreen.SetActive(false);
				MainMenu.SetActive(true);
			}
			else if (CurrentSelec == QuitButton)
			{
				QuitGame();
			}
		}
	}

	public void PlayGame()
	{
		SceneManager.LoadScene(1);
		Time.timeScale = 1f;
	}

	public void OptionContents()
	{
		OptionsScreen.SetActive(true);
		MainMenu.SetActive(false);
	}

	public void HighScoreStore()
	{
		LeaderBoardScreen.SetActive(true);
		MainMenu.SetActive(false);
		h_Scores.LoadScoresFromFile();
		Score_1.text = h_Scores.scoreArray[0].ToString();
		Score_2.text = h_Scores.scoreArray[1].ToString();
		Score_3.text = h_Scores.scoreArray[2].ToString();
		Score_4.text = h_Scores.scoreArray[3].ToString();
		Score_5.text = h_Scores.scoreArray[4].ToString();
	}

	public void QuitGame()
	{
		// Quits the application if exe file
#if UNITY_STANDALONE
		Application.Quit();
#endif

		// Stops the editor playing if in unity
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
	}

}
