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
            player.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Debug.Log("trigger entered");
            //put player hit sound into here.
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.GetComponent<SpriteRenderer>().color =Color.white;
        }
    }   
}

