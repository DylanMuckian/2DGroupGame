using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

// Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
   

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public bool canMove = true;



    public float activeMovespeed;
    public float dashSpeed;

    public float dashLength = 0.5f, dashCooldown = 1.0f;
    private bool canDash = false;
    private float dashCounter;
    private float dashCoolCounter;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();
        activeMovespeed = moveSpeed;
    }
    private void Update()
    {
        if (canDash == true) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
               if(dashCoolCounter <=0 && dashCounter <= 0)
               {
                activeMovespeed = dashSpeed;
                dashCounter = dashLength;
               }
            }
        }
        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                activeMovespeed = moveSpeed;
                dashCoolCounter = dashLength;
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
        
    }
       
    private void FixedUpdate()
    {
        if (canMove)
        {
            // If movement input is not 0, try to move
            if (movementInput != Vector2.zero)
            {

                bool success = TryMove(movementInput);

                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));
                    
                }

                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                    
                }
                animator.SetFloat("X", movementInput.x);
                animator.SetBool("IsMoving", success);
                animator.SetFloat("Y", movementInput.y);
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }

 
        }
    }

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            // Check for potential collisions
            int count = rb.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
                movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                activeMovespeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset

            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * activeMovespeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            // Can't move if there's no direction to move in
            return false;
        }

    }

    void OnMovement(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }

    //cant dash untill obtained the amulet item.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Amulet"))
        {
            canDash = true;
        }
    }
}
