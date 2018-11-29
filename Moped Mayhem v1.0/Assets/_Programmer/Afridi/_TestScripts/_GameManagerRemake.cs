using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _GameManagerRemake : MonoBehaviour {

    public _ScoreControl sController;
    public Text ScoreTxt;
    public Text TotalScoreTxt;
    public Text Timer;
    public InputField input;
    public AudioSource NoReturn;
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
        Cursor.visible = false;
    }

    private void Update()
    {
        Timer.text = DurationOfGame.ToString();
        if (!hasLost)
        {
            ScoreTxt.text = sController.Score.ToString();
            PointOfNoReturn();
        }
        else {
            TotalScoreTxt.text = sController.Score.ToString();
            sController.name = input.text;
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

    void PointOfNoReturn() {
        if (DurationOfGame <= 65.500) {
            NoReturn.pitch = 1.15f;
        }
    }
}
