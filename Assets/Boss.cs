using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Boss : MonoBehaviour
{
    
    public float checkRadius;
    public float attackRadius;

    public bool facingRight = true;
    public bool LastfacingRight = true;

    public LayerMask WhatisPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isinChaseRange;
    private bool isinAttackRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        anim.SetBool("canMove", isinChaseRange);
        anim.SetBool("Attacking", isinAttackRange);
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
       
        if (isinAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }

  

}
