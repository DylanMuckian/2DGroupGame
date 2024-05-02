using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Damage : MonoBehaviour

{
   
    public PlayerHealth pHealth;
    public float damage = 20;

    private GameObject player;

    public AudioSource source;
    public AudioClip clip;
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
        if (other.CompareTag("Spear"))
        {
            source.PlayOneShot(clip);
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

