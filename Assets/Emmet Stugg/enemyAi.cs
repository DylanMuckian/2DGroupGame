using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class aiMove : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

    public bool facingRight = true;
    public bool LastfacingRight = true;

    public LayerMask WhatisPlayer;

    private Transform target;
    private Rigidbody2D rb;
    //private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isinChaseRange;
    private bool isinAttackRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        //anim.SetBool("isRunning", isinChaseRange);

        isinChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, WhatisPlayer);
        isinAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, WhatisPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        movement = dir;

        if (dir.x >= 0) facingRight = true;
        else facingRight = false;

        if (facingRight != LastfacingRight)
        {

            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        LastfacingRight = facingRight;
    }
    private void FixedUpdate()
    {
        if (isinChaseRange && !isinAttackRange)
        {
            MoveChracter(movement);
        }
        if (isinAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveChracter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

}
