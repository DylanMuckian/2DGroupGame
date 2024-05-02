using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    public SpriteRenderer sr;
    public Animator animator;
    public AudioSource source;
    public AudioClip hit;

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
            BossHealth boss = other.GetComponent<BossHealth>();
            
            if (enemy != null)
            {
                enemy.Health -= damage;
                EnemyHitAnim();
                source.PlayOneShot(hit);
            }
            if (boss != null)
            {
                boss.Health -= damage;
                source.PlayOneShot(hit);
            }
        }
    }

    public void EnemyHitAnim() 
    { 
        animator.SetTrigger("Hurt");
    }
}
