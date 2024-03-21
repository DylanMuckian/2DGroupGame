using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLazer : MonoBehaviour
{
    public Material material;
    LazerBeam beam;
    void Update()
    {
        //game object destroyed so that it isnt created every update
        Destroy(GameObject.Find("Laser Beam"));
        beam = new LazerBeam(gameObject.transform.position, gameObject.transform.right, material);
    }
}