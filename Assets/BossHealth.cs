using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    Animator animator;
    public Image healthBar;
    public Image healthBorder;
    public float maxHealth = 500;
   
    public float Health
    {
        set
        {
            health = value;
            
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
    public void Update()
    {
<<<<<<< Updated upstream
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0.0f, 1.0f); 
        }
        else
        {
            print("Health Bar not set in the inspector");
        }
        

      //if (AR.canMove == true)
      // {
            //healthBar.gameObject.SetActive(true);
         // healthBorder.gameObject.SetActive(true);
       // }
=======
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0.0f, 1.0f);
       
      
>>>>>>> Stashed changes
        if (health <= 250)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }
        if(health <= 0)
        {
            healthBar.gameObject.SetActive(false);
            healthBorder.gameObject.SetActive(false);
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

  
}
