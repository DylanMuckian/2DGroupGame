using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLazer : MonoBehaviour
{
    public Material material;
    LazerBeam beam;
    private bool miniGameFinish;

    public void Start()
    {
        miniGameFinish = false;
    }
    void Update()
    {
        //game object destroyed so that it isnt created every update
        if (!miniGameFinish)
        {
            Destroy(GameObject.Find("Laser Beam"));
            beam = new LazerBeam(gameObject.transform.position, gameObject.transform.right, material);
            Debug.Log("looping");
        }

        else
        {
            Debug.Log("remove");
            //beam.gameObject.SetActive(false);
            // beam = Destroy(beam.gameObject);
            //Destroy(beam);
          
        }
    }
    public void miniGameFinished()
    {
        miniGameFinish=true;
        Debug.Log("Finished");
    }
}