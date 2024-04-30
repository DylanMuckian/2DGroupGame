using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{

    public static BossHealth Instance;

    Animator animator;
    public Image healthBar;
    public Image healthBorder;
    public float maxHealth = 500;
    public GameObject Amulet;
    public GameObject Door;
    public GameObject Exit;
    public GameObject potion;
    Boss bossH;
    private void Awake()
    {
        Instance = this;
    }
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

        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0.0f, 1.0f); 
        }
        else
        {
            print("Health Bar not set in the inspector");
        }
        


        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0.0f, 1.0f);
       
      if (health < maxHealth)
        {
            Beginning();
        }

        if (health <= 250)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
            GetComponent<Boss>().Enraged();
        }
     
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void Defeated()
    {
        animator.SetTrigger("Defeated");
        Destroy(Door.gameObject);
        Amulet.gameObject.SetActive(true);
        Destroy(Exit.gameObject);
        Destroy(healthBar);
        Destroy(healthBorder);
        potion.gameObject.SetActive(true);
    }
    public void Beginning()
    {
        healthBar.gameObject.SetActive(true);
         healthBorder.gameObject.SetActive(true);
        Exit.gameObject.SetActive(true);

    }

}
