using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ScoreControl : MonoBehaviour {

    // Variables used for score keeping
    public int Score;
    public int ScoreContainer;
    public float scoreTimer;
    private float scoreDelay;

    private void Awake()
    {
        scoreDelay = scoreTimer;
    }

    private void FixedUpdate()
    {
        // Increases the score as along as the player hasnt died
        if (scoreDelay <= 0)
        {
            scoreDelay = scoreTimer;
            Score++;
        }
        else
        {
            scoreDelay -= Time.deltaTime;
        }
    }
}
