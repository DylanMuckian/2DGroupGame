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
        if (Physics2D.Raycast(m_transform.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            Draw2DRay(laserFirePoint.position, _hit.point);
            
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
   private void checkHit(RaycastHit hitInfo, Vector3 direction, LineRenderer laser)
    {
        if (hitInfo.collider.gameObject.tag == "Player")
        {
            GetComponent<PlayerHealth>().health -= damage;
        }
    }
}
