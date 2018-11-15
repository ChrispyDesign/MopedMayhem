using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _TestPauseMenu : MonoBehaviour {

    public static bool isGamePaused;
    public GameObject PauseMenuObj;
    public GameObject OptionsMenuObj;
    public InputField Name;
    public _ScoreControl scoreControl;
    public _TestHighScore tscore;

    private void Awake()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume() {
        PauseMenuObj.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void Pause()
    {
        PauseMenuObj.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void Restart() {
        tscore.AddScore(scoreControl.Score);
        tscore.SaveScoresToFile(); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        tscore.AddScore(scoreControl.Score);
        tscore.SaveScoresToFile();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void QuitGame() {
        tscore.AddScore(scoreControl.Score);
        tscore.SaveScoresToFile();
        SceneManager.LoadScene(0);
    }

    public void OptionsBtn() {
        PauseMenuObj.SetActive(false);
        OptionsMenuObj.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void OptionsBack() {
        PauseMenuObj.SetActive(true);
        OptionsMenuObj.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
}
