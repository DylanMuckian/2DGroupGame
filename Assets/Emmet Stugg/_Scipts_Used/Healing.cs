using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Healing : MonoBehaviour
{
    Collider2D colider;
    public PlayerHealth pHealth;
    public float healing;
    public GameObject bottle;
    public AudioSource source;
    public AudioClip clip;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().health += healing;
            Debug.Log("trigger entered");
            Destroy(bottle);
            source.PlayOneShot(clip);
        }
    }

}
