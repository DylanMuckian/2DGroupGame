using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private int speed = 5;

    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;

    bool _isFacingRight = true;
    float horizontalInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        SetFacingDirection(horizontalInput);
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {
        //Varient 1
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void SetFacingDirection(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            //Face the right
            //IsFacingRight = true;
            Debug.Log("right");
            transform.localScale = new Vector2(1, 1);
        }
        else if (horizontalInput < 0)
        {
            //Face to left
            //IsFacingRight = false;
            Debug.Log("left");
            transform.localScale = new Vector2(-1, 1);
        }
    }

}

