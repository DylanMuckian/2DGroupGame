using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class LazerBoss : MonoBehaviour
{
    [SerializeField] private float defDinstancRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;
    public float damage;
    
    //this for doing DPS instead of damage at the speed of update
    public float damagePerSecondRate = 0.5f;
    private float damageTimer = 0;

    public bool hitPlayer;
    
    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        ShootLaser();
    }
    void ShootLaser()
    {
        RaycastHit2D hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
        
        if (Physics2D.Raycast(m_transform.position, transform.right))
        {
            
            Draw2DRay(laserFirePoint.position, hit.point);
            checkHit(hit, transform.right, m_lineRenderer);
        }
        else
        {
            Draw2DRay(laserFirePoint.position,laserFirePoint.transform.right * defDinstancRay);
        }
       
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
    private void checkHit(RaycastHit2D hitInfo, Vector3 direction, LineRenderer laser)
    {
        if (hitInfo.collider.gameObject.tag == "Player")
        {
            //hitInfo.collider.gameObject.GetComponent<PlayerHealth>().health -= damage;
            Debug.Log("Player Hit BY BOSS LAZER");
            
            //damage per second timer
            damageTimer += Time.deltaTime;
            if (damageTimer >= damagePerSecondRate)
            {
                hitInfo.collider.gameObject.GetComponent<PlayerHealth>().health -= damage;
                damageTimer = 0;
            }
        }
    }
}
