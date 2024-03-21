using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Damage : MonoBehaviour

{
    private int spawn = 0;
    public PlayerHealth pHealth;
    public float damage = 20;

    private GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().health -= damage;
            player = other.gameObject;
            Debug.Log("trigger entered");
        }
    }
    private void Update()
    {
        Dead();
    }
    public void Dead()
    {

        if (pHealth.health <= 0f)
        {
            Debug.Log("dead: " + pHealth.health);
            Destroy(player);
            SceneManager.LoadScene(spawn);
        }


    }
}

