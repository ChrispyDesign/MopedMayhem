using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _GameManagerRemake : MonoBehaviour {

    public _ScoreControl sController;
    public Text ScoreTxt;
    public Text Timer;
    public Canvas LostGame;
    private bool hasLost = false;
    public bool hasDied = false;
    public float DurationOfGame = 0f;

    private void Awake()
    {
        sController = FindObjectOfType<_ScoreControl>();
        LostGame.gameObject.SetActive(false);
        hasLost = false;
        hasDied = false;
    }

    private void Update()
    {
        Timer.text = DurationOfGame.ToString();
        if (!hasLost)
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
            hasDied = true;
            LostGame.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
