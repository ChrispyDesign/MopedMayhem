using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _TestMenuManager : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject PlayButton;
    public GameObject QuitButton;
    public GameObject OptionsButton;
    public GameObject OptionsBackButton;
    public GameObject ControlButton;
    public GameObject ControlBackButton;
    public GameObject LeaderButton;
    public GameObject LeaderBackButton;

    public _TestHighScore h_Scores;
    public GameObject LeaderBoardScreen;
    public GameObject OptionsScreen;
    public GameObject ControlScreen;
    public GameObject CharacterSelect;

    public Text Score_1;
    public Text Score_2;
    public Text Score_3;
    public Text Score_4;
    public Text Score_5;

    public Text Name1;
    public Text Name2;
    public Text Name3;
    public Text Name4;
    public Text Name5;

    public GameObject CurrentSelec;
    public Button CurrentButton;

    void Awake()
    {
        h_Scores = FindObjectOfType<_TestHighScore>();
        CurrentSelec = PlayButton;
        CurrentButton = CurrentSelec.GetComponent<Button>();
    }

    void Update () {

        /*These Controls work with both PC and PS4 (Unsure for Xbox)*/
        if (Input.GetButtonDown("Submit"))
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
                //Option Included Stuff
                /*Control (Music, Effects), Resolution, Invert Controls?, Customise Controls? or Schemes?, Mutator Settings*/
            }
            else if (CurrentSelec == OptionsBackButton)
            {
                CurrentSelec = OptionsButton;
                OptionsScreen.SetActive(false);
                MainMenu.SetActive(true);
            }
            else if (CurrentSelec == ControlButton)
            {
                ControlContents();
                CurrentSelec = ControlBackButton;
            }
            else if (CurrentSelec == ControlBackButton) {
                CurrentSelec = ControlButton;
                ControlScreen.SetActive(false);
                OptionsScreen.SetActive(true);
            }
            else if (CurrentSelec == QuitButton)
            {
                QuitGame();
            }
        }
	}

    public void SelectDemCharacters() {
        MainMenu.SetActive(false);
        CharacterSelect.SetActive(true);
    }

    public void PlayGame() {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void OptionContents() {
        OptionsScreen.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void HighScoreStore() {
        LeaderBoardScreen.SetActive(true);
        MainMenu.SetActive(false);
        h_Scores.LoadScoresFromFile();
        h_Scores.LoadNameFromFile();
        Score_1.text = h_Scores.scoreArray[0].value.ToString();
        Name1.text = h_Scores.scoreArray[0].name;

        Score_2.text = h_Scores.scoreArray[1].value.ToString();
        Name2.text = h_Scores.scoreArray[1].name;

        Score_3.text = h_Scores.scoreArray[2].value.ToString();
        Name3.text = h_Scores.scoreArray[2].name;

        Score_4.text = h_Scores.scoreArray[3].value.ToString();
        Name4.text = h_Scores.scoreArray[3].name;

        Score_5.text = h_Scores.scoreArray[4].value.ToString();
        Name5.text = h_Scores.scoreArray[4].name;
    }

    public void ControlContents() {
        ControlScreen.SetActive(true);
        OptionsScreen.SetActive(false);
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
