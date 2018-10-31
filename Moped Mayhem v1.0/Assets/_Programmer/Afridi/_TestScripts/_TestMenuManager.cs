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
    }

    public void OptionContents() {

    }

    public void HighScoreStore() {
        LeaderBoardScreen.SetActive(true);
        MainMenu.SetActive(false);
        h_Scores.LoadScoresFromFile();
    }

    public void SoundContents() {

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
