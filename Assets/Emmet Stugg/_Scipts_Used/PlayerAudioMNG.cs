using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioMNG : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerHealth.health <= 0)
        {
            source.PlayOneShot(clip);
        }
    }  
}
