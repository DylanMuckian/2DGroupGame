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
        }

        else
        {
            Destroy(GameObject.Find("Laser Beam"));
        }
    }
    public void miniGameFinished()
    {
        miniGameFinish=true;
    }
}