using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public bool canShoot = false;

    public Rigidbody2D rb;
    private Vector2 movement;

    private Inverted iControl;
    private Normal nControl;

    private bool invert = true;

    private bool alreadyInverted = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        iControl = new Inverted();
        nControl = new Normal();
    }

    private void Update()
    {
        GetInputs();
        if(canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            ScoreManager.instance.HitDuck();
        }

        if (!alreadyInverted && ScoreManager.instance.GetDucksMissed() % 2 == 0)
        {
            alreadyInverted = true;
            invert = !invert;
        }
        if (ScoreManager.instance.GetDucksMissed() % 2 != 0) alreadyInverted = false;
        
    }

    private void FixedUpdate()
    {
        MoveAim();
    }

    private void GetInputs()
    {

        movement.y = (invert ? iControl.Control() : nControl.Control());
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    private void MoveAim()
    {
        rb.velocity = movement * speed * ScoreManager.instance.GetRound();
    }
}
