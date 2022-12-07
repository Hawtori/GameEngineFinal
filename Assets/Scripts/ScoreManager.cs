using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; set; }

    public TMP_Text dRemaining, dHit, dScore, dRound;

    public GameObject currentDuck = null;

    private int totalDucks = 0;

    private int round = 1;

    private int score = 0;
    private int ducksHit = 0;
    private int ducksRemaining = 10;

    private int ducksMissed = 0;

    private float timeToSpawn = 3f;

    private bool canInvoke = true;

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
        dRound.text = "Round: " + round;

        if (ducksRemaining > 0 && canInvoke) { Invoke("SpawnDuck", timeToSpawn); canInvoke = false; }

        if (ducksRemaining == 0 && canInvoke) ResetRound();

        if (totalDucks == 26) SceneManager.LoadScene(2);
        else if (round == 4) SceneManager.LoadScene(3);


    }

    public int GetDucksMissed() => ducksMissed;

    public void SpawnDuck()
    {
        ThrowDuck();
        GameObject d = DuckPool.instance.GetDuck();
        Vector2 pos = new Vector2(Random.Range(-6f, 6.01f), -6f);
        d.transform.position = pos;
        canInvoke = true;
    }

    public void IncreaseScore()
    {
        score += 10;
        if (ducksHit == 10) score += 15;
    }

    public void HitDuck()
    {
        totalDucks++;
        ducksHit++;
        DuckPool.instance.ReturnDuck(currentDuck);
        currentDuck = null;
        IncreaseScore();
    }

    public void ThrowDuck()
    {
        ducksRemaining--;
    }

    public void MissedDuck()
    {
        ducksMissed++;
        DuckPool.instance.ReturnDuck(currentDuck);
        currentDuck = null;
    }

    public void ResetRound()
    {
        CancelInvoke();
        round++;
        ducksHit = 0;
        ducksRemaining = 10;
        timeToSpawn--;
        ducksMissed = 0;
    }

    public int GetRound() => round;
}
