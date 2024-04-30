using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float health = 100;

    Animator animator;
<<<<<<< HEAD
<<<<<<< HEAD
    public Slider healthSlider;
    
=======
   
>>>>>>> 7f24c6a4da7f73b6c19f554b93791f5e00782ee2
=======
   
>>>>>>> 7f24c6a4da7f73b6c19f554b93791f5e00782ee2
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

<<<<<<< HEAD
    


=======
    public float health = 1;
    
 
<<<<<<< HEAD
>>>>>>> 7f24c6a4da7f73b6c19f554b93791f5e00782ee2
=======
>>>>>>> 7f24c6a4da7f73b6c19f554b93791f5e00782ee2
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
