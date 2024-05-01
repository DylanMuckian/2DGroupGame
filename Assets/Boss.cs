using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // this scripts is to flip the sprite when player switchs sides of boss
     private float checkRadius = 6.5f;
     private float attackRadius = 1.5f;

    public bool facingRight = true;
    public bool LastfacingRight = true;

    public LayerMask WhatisPlayer;

    private Transform target;
   
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isinChaseRange;
    private bool isinAttackRange;

    public AudioSource source;
    public AudioClip charge;
    public AudioClip fire;

    private void Start()
    {
       
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        anim.SetBool("IsMoving", isinChaseRange);
        anim.SetBool("IsAttacking", isinAttackRange);
         isinChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, WhatisPlayer);
        isinAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, WhatisPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        movement = dir;

        if (dir.x >= 0) facingRight = true;
        else facingRight = false;

        if (facingRight != LastfacingRight)
        {
            GetComponent<SpriteRenderer>().flipX = false;
         
        }

        if(facingRight== true)
        {
            anim.SetBool("FacingLeft",false);
        }
        if (facingRight == false)
        {
            anim.SetBool("FacingLeft",true);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        LastfacingRight = facingRight;

        if (isinChaseRange)
        {
            anim.SetBool("IsMoving", true);
        }
      



        
    }
    public void Enraged()
    {
        attackRadius = 5;
        Debug.Log("Enraged");
    }
    public void Charge()
    {
        source.PlayOneShot(charge);
    }
    public void Fire()
    {
        source.PlayOneShot(fire);
    }
}
