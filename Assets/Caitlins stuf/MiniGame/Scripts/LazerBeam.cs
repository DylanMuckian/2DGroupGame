using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LazerBeam : MonoBehaviour
{
    Vector3 pos, dir;
    private GameObject laserObject;
    GameObject laserObj;
    LineRenderer laser;
    List<Vector3> laserIndices = new List<Vector3>();

    public void Start()
    {
        laserObject = GameObject.Find("Laser");
    }
    public LazerBeam(Vector3 pos, Vector3 dir, Material material)
    {
        this.laser = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.name = "Laser Beam";
        this.pos = pos;
        this.dir = dir;

        this.laser = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        //colour of line renderer/material/width
        this.laser.startWidth = 0.1f;
        this.laser.endWidth = 0.1f;
        this.laser.material = material;
        this.laser.startColor = Color.blue;
        this.laser.endColor = Color.blue;

        CastRay(pos, dir, laser);
    }

    void CastRay(Vector3 pos, Vector3 dir, LineRenderer laser)
    {
        laserIndices.Add(pos);


        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        //if the ray hits an object it adds the position of where it glides to the laser indices list.
        if (Physics.Raycast(ray, out hit, 30, 1))
        {
            CheckHit(hit, dir, laser);
        }
        else
        //add 30 units along the ray to the lazer indices list.
        {
            laserIndices.Add(ray.GetPoint(30));
            updateLaser();
        }

    }

    void updateLaser()
    {
        int count = 0;
        laser.positionCount = laserIndices.Count;

        foreach (Vector3 idx in laserIndices)
        {
            laser.SetPosition(count, idx);
            count++;
        }

    }

    void CheckHit(RaycastHit hitInfo, Vector3 direction, LineRenderer laser)
    {
      //  Debug.Log("Hit" + hitInfo.collider.gameObject.name);

        if (hitInfo.collider.gameObject.tag == "Mirror")
        {
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);

            CastRay(pos, dir, laser);
        }
        else
        {
            laserIndices.Add(hitInfo.point);
            updateLaser();
        }

        //if the ray hits the end point it opens the door
        if (hitInfo.collider.gameObject.tag == "MirrorEnd")
        {
         //Debug.Log("objectHit");
            laserIndices.Remove(pos);
<<<<<<< Updated upstream
         // laserObject.GetComponent<ShootLazer>().miniGameFinished();
            Destroy(GameObject.Find("Door"));
            Destroy(this.laser);
            Destroy(GameObject.Find("MiniGame"));
   
        }

        if (hitInfo.collider.gameObject.tag == "MirrorEnd2")
        {
         // Debug.Log("objectHit");
            laserIndices.Remove(pos);
         //laserObject.GetComponent<ShootLazer>().miniGameFinished();
            Destroy(GameObject.Find("Door2"));
            Destroy(this.laser);
            Destroy(GameObject.Find("MiniGame2"));
     
        }
        if (hitInfo.collider.gameObject.tag == "MirrorEnd3")
        {
         //Debug.Log("objectHit");
            laserIndices.Remove(pos);
         //laserObject.GetComponent<ShootLazer>().miniGameFinished();
            Destroy(GameObject.Find("Door3"));
            Destroy(this.laser);
            Destroy(GameObject.Find("MiniGame3"));

=======
            // laserObject.GetComponent<ShootLazer>().miniGameFinished();
            Destroy(GameObject.Find("Door"));
            Destroy(this.laser);
            Destroy(GameObject.Find("MiniGame"));
            // Destroy(GameObject.Find("laserBeam"));

        }
        if (hitInfo.collider.gameObject.tag == "MirrorEnd2")
        {
            Debug.Log("objectHit");
            laserIndices.Remove(pos);
            // laserObject.GetComponent<ShootLazer>().miniGameFinished();
            Destroy(GameObject.Find("Door2"));
            Destroy(this.laser);
            Destroy(GameObject.Find("MiniGame2"));
            // Destroy(GameObject.Find("laserBeam"));

>>>>>>> Stashed changes
        }
    }
}

