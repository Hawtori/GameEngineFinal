using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public Vector2 destination;

    public Rigidbody2D rb;

    private void Start()
    {
        int x = Random.Range(0, 2);
        if (x == 0) destination.x = -18f;
        else destination.x = 18f;

        destination.y = 9;

        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        Vector2 target = new Vector2(destination.x - transform.position.x, destination.y - transform.position.y);
        rb.velocity = target.normalized * ScoreManager.instance.GetRound() * 1.15f;

        if(Vector2.Distance(destination, transform.position) < Random.Range(0.2f, 1f))
        {
            ScoreManager.instance.currentDuck = gameObject;
            ScoreManager.instance.MissedDuck();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { collision.GetComponent<Player>().canShoot = true; ScoreManager.instance.currentDuck = this.gameObject; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { collision.GetComponent<Player>().canShoot = false; ScoreManager.instance.currentDuck = null; }
    }
}
