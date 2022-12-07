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
        rb.velocity = target.normalized * ScoreManager.instance.GetRound();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) collision.GetComponent<Player>().canShoot = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) collision.GetComponent<Player>().canShoot = false;
    }
}
