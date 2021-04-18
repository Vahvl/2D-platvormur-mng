﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tegelaanius : Damage
{
  
    private Vector3 dir;
    public float speed = 3f;
    public int lives = 5;
    public float jumpForce = 0.1f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private bool isGrounded = false;

    public static Tegelaanius Instance { get; set; }

    public override void GetDamage()
    {
        Lives -= 1;
        Debug.Log(lives);

        if (lives < 1)
        {
            //Die();
        }
    }

    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 5) lives = value;
            healthBar.Refresh();
        }
    }

    private HealthBar healthBar;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();

        Instance = this;

        healthBar = FindObjectOfType<HealthBar>();

    }

    private void Run()
    {

        if (isGrounded) State = States.run;


        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;



    }

    private void checkGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

        if (!isGrounded) State = States.jump;

    }



    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isGrounded) State = States.idle;


        if (Input.GetButton("Horizontal"))
        {
            Run();
        }

        if (isGrounded && Input.GetButton("Jump"))
        {
            Jump();
        }


    }

    private void FixedUpdate()
    {
        checkGround();
    }

}

public enum States
{
    idle,
    run,
    jump
}



