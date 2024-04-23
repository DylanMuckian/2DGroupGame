using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    public SpriteRenderer sr;
    public Animator animator;

    // Start is called before the first frame update
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("HIT");
            // Deal damage to the enemy
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Health -= damage;
                EnemyHitAnim();
            }
        }
    }

    public void EnemyHitAnim() 
    { 
        animator.SetTrigger("Hurt");
    }
}
