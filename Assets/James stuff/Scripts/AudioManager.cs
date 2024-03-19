using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource BGM;  // Searches for an AudioSource

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

}
