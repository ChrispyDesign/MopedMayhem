using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _TestPauseMenu : MonoBehaviour {

    public static bool isGamePaused;
    public GameObject PauseMenuObj;
    public GameObject OptionsMenuObj;
    public GameObject ControlsMenuObj;
    public _ScoreControl scoreControl;
    public GameObject MiniMapCanvas;
    public GameObject MainCanvas;
    public _TestHighScore tscore;

    private void Awake()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
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
        MiniMapCanvas.SetActive(true);
        MainCanvas.SetActive(true);
        Time.timeScale = 1f;
        isGamePaused = false;
        Cursor.visible = false;
    }

    public void Pause()
    {
        PauseMenuObj.SetActive(true);
        MiniMapCanvas.SetActive(false);
        MainCanvas.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
        Cursor.visible = true;
    }

    public void Restart() {
        tscore.AddScore(scoreControl.Score, scoreControl.name);
        tscore.SaveScoresToFile();
        tscore.SaveNamesToFile();
        SceneManager.LoadScene(1);
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        tscore.AddScore(scoreControl.Score, scoreControl.name);
        tscore.SaveScoresToFile();
        tscore.SaveNamesToFile();
        SceneManager.LoadScene(1);
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void QuitGame() {
        tscore.AddScore(scoreControl.Score, scoreControl.name);
        tscore.SaveScoresToFile();
        tscore.SaveNamesToFile();
        SceneManager.LoadScene(0);
        Cursor.visible = true;
    }

    public void OptionsBtn() {
        PauseMenuObj.SetActive(false);
        OptionsMenuObj.SetActive(true);
        MiniMapCanvas.SetActive(false);
        MainCanvas.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
        Cursor.visible = true;
    }

    public void ControlsBtn()
    {
        PauseMenuObj.SetActive(false);
        ControlsMenuObj.SetActive(true);
        MiniMapCanvas.SetActive(false);
        MainCanvas.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
        Cursor.visible = true;
    }

    public void OptionsBack() {
        PauseMenuObj.SetActive(true);
        OptionsMenuObj.SetActive(false);
        MiniMapCanvas.SetActive(false);
        MainCanvas.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
        Cursor.visible = true;
    }
    public void ControlsBack()
    {
        PauseMenuObj.SetActive(true);
        ControlsMenuObj.SetActive(false);
        MiniMapCanvas.SetActive(false);
        MainCanvas.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
        Cursor.visible = true;
    }

}
