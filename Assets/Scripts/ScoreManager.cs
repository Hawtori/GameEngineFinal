using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; set; }

    public TMP_Text dRemaining, dHit, dScore;

    private int round = 1;

    private int score = 0;
    private int ducksHit = 0;
    private int ducksRemaining = 10;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        dRemaining.text = "Ducks remaining: " + ducksRemaining + "/10";
        dHit.text = "Ducks hit: " + ducksHit + "/10";
        dScore.text = "Score: " + score;

        if (ducksRemaining == 0) ResetRound();
    }

    public void IncreaseScore()
    {
        score += 10;
        if (ducksHit == 10) score += 5;
    }

    public void HitDuck()
    {
        ducksHit++;
        IncreaseScore();
    }

    public void ThrowDuck()
    {
        ducksRemaining--;
    }

    public void ResetRound()
    {
        round++;
        ducksHit = 0;
        ducksRemaining = 10;
    }

    public int GetRound() => round;
}
