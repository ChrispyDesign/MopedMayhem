using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _GameManagerRemake : MonoBehaviour {

    public _TestHighScore Score;
    public _ScoreControl sController;
    public Text ScoreTxt;
    public Text Timer;
    public Canvas LostGame;
    private bool hasLost = false;
    public float DurationOfGame = 0f;

    private void Awake()
    {
        sController = FindObjectOfType<_ScoreControl>();
        Score = FindObjectOfType<_TestHighScore>();
        LostGame.gameObject.SetActive(false);
        hasLost = false;
    }

    private void Update()
    {
        Timer.text = DurationOfGame.ToString();
        if (hasLost == false)
        {
            ScoreTxt.text = sController.Score.ToString();
        }
        LoseTheGame();
    }

    void LoseTheGame() {
        DurationOfGame -= Time.deltaTime;
        if (DurationOfGame <= 0.0001) {
            DurationOfGame = 0f;
            hasLost = true;
            Score.AddScore(sController.Score);
            Score.SaveScoresToFile();
            LostGame.gameObject.SetActive(true);
        }
    }
}
