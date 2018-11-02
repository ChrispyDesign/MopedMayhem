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
    public GameObject SoundButton;
    public GameObject SoundBackButton;
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
                /*Sound (Music, Effects), Resolution, Invert Controls?, Customise Controls? or Schemes?, Mutator Settings*/
            }
            else if (CurrentSelec == OptionsBackButton)
            {
                CurrentSelec = OptionsButton;
                OptionsScreen.SetActive(false);
                MainMenu.SetActive(true);
            }
            else if (CurrentSelec == SoundButton)
            {
                SoundContents();
                CurrentSelec = SoundBackButton;
            }
            else if (CurrentSelec == SoundBackButton) {
                CurrentSelec = SoundButton;
                SoundScreen.SetActive(false);
                OptionsScreen.SetActive(true);
            }
            else if (CurrentSelec == QuitButton)
            {
                QuitGame();
            }
        }
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
        Score_1.text = h_Scores.scoreArray[0].ToString();
        Score_2.text = h_Scores.scoreArray[1].ToString();
        Score_3.text = h_Scores.scoreArray[2].ToString();
        Score_4.text = h_Scores.scoreArray[3].ToString();
        Score_5.text = h_Scores.scoreArray[4].ToString();
    }

    public void SoundContents() {
        SoundScreen.SetActive(true);
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
