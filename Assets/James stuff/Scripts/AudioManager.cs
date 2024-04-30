using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;  // Creates an instance of the AudioManager

    public AudioSource BGM;  // Searches for an AudioSource

    private void Awake()
    {
        instance = this;  // Sets the instance to this AudioManager
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);  // Doesn't destroy when the player starts the game in a new scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBGM(AudioClip music) // changes Background music
    {
        if (BGM.clip.name == music.name)
            return;

        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
    
    //function to play sound effects - pass in an audio clip to this function to play it
    public void PlaySFX(AudioClip sfx)
    {
        AudioSource SFX = gameObject.AddComponent<AudioSource>();
        SFX.clip = sfx;
        SFX.Play();
        Destroy(SFX, sfx.length);
    }
    
    //function to play sound effects via a string name - pass in the name of the audio file to play it from the resources folder
    public void PlaySFX(string sfxName)
    {
        AudioClip sfx = Resources.Load<AudioClip>("Audio/" + sfxName);
        if (sfx == null)
        {
            Debug.LogError("Unable to locate audio file: " + sfxName);
            return;
        }
        PlaySFX(sfx);

    }
    
}
