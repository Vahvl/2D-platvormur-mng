using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wolkiman : Damage

{
    private int lives = 5;
    private float speed = 2f;
    private Vector3 dir;
    private SpriteRenderer sprite;

    void Start()
    {
        dir = transform.right * -1;

    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    private void Move()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 0.7f, 0.1f);

        if (collider.Length > 0)
        {
            dir *= -1f;
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

    }

    
    
}
