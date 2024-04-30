using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{

    Collider2D col;
    public int spawn;
    public float health = 100;
    public float maxHealth = 100;
    public Image healthbar;
   
    public bool isDead;
    Animator animator;
    PlayerController playerController;

    private AudioClip deathSound;
    private AudioSource audioSource;
    public GameObject audioMngr;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        deathSound = (AudioClip)Resources.Load("Church Bell");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        
        healthbar.fillAmount = Mathf.Clamp(health / maxHealth, 0.0f, 1.0f);
        if (health > maxHealth) health = maxHealth;

        if (health <= 0) 
        {
            animator.SetBool("IsDead", true);
            playerController.enabled = false;
            audioSource.clip = deathSound;
            audioSource.Play();

        }
        else 
        {
            animator.SetBool("IsDead", false);
            playerController.enabled = true;
        }
    }


}