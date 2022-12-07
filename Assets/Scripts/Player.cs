using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public bool canShoot = false;

    public Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInputs();
        if(canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            //return enemy to pool
            ScoreManager.instance.HitDuck();
        }
    }

    private void FixedUpdate()
    {
        MoveAim();
    }

    private void GetInputs()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void MoveAim()
    {
        rb.velocity = movement * speed * ScoreManager.instance.GetRound();
    }
}
