using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    Animator animator;

    public float Health
    {
        set
        {
            health = value;
            if (health <= 250)
            {
                GetComponent<Animator>().SetBool("isEnraged", true);
            }
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

    public float health = 1;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void Defeated()
    {
        animator.SetTrigger("Defeated");

    }

  
}
