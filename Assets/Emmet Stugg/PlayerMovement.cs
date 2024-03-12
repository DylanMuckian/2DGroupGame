using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] private GameObject spearPrefab;
    [SerializeField] private Transform firingPoint;
    //[Range(0.1f, 1f)]
    //[SerializeField] private float fireRate = 0.5f;


    [SerializeField] private float speed = 5f;

    public Rigidbody2D rb;
    private float mx;
    private float my;

    private Vector2 mousePos;
    public GameObject sword;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Start is called before the first frame update


    // Update is called once per frame
    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        sword.transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx, my).normalized * speed;
    }
    
    private void Shoot()
    {
        Instantiate(spearPrefab, firingPoint.position, firingPoint.rotation);
    }

}
