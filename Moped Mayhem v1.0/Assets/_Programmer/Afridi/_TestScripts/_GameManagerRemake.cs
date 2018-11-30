// Main Author - Afridi Rahim
//
// Date last worked on --/--/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _GameManagerRemake : MonoBehaviour {

    public _ScoreControl sController;
    public Text ScoreTxt;
    public Text TotalScoreTxt;
    public InputField input;
    public AudioSource NoReturn;
    public GameObject LostGame;
    public GameObject MinuteBox, SecondBox;
    private bool hasLost = false;
    public bool hasDied = false;
    public int m_iTimeLimit;
    private int Min, Sec;
    private float fSeconds;

    private void Awake()
    {
        sController = FindObjectOfType<_ScoreControl>();
        LostGame.SetActive(false);
        hasLost = false;
        hasDied = false;
        Min = m_iTimeLimit;
        Sec = 1;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!hasLost)
        {
            int.TryParse(ScoreTxt.text, out sController.Score);
            PointOfNoReturn();
        }
        else {
            TotalScoreTxt.text = ScoreTxt.text;
            sController.name = input.text;
        }
        GameLoop();
    }

    void LoseTheGame() {
        hasLost = true;
        hasDied = true;
        LostGame.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0f;
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
            LoseTheGame();
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

    void PointOfNoReturn() {
        if (Min < 1 && Sec <= 20.0f) {
            NoReturn.pitch = 1.5f;
        }
    }
}
