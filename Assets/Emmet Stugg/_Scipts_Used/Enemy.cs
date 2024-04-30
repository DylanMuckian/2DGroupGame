using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float health = 100;

    Animator animator;
    public Slider healthSlider;
    
    public float Health
    {
        set
        {
            health = value;
            healthSlider.value = health;

            if (health <= 0)
            {
                Defeated();
                
            }
        }
        get
        {
            return health;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
   


    public void Defeated()
    {
        animator.SetTrigger("Defeated");
        
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}
