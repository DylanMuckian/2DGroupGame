using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spear_Throw : MonoBehaviour
{


    [SerializeField] private GameObject spearPrefab;
    [SerializeField] private Transform firingPoint;
    //[Range(0.1f, 1f)]
    //[SerializeField] private float fireRate = 0.5f;

    private Vector2 mousePos;

    public float coolDown = 0.5f;
    public float timer;
    private bool canShoot = false;

    // Update is called once per frame
    private void Update()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(dir.y - transform.position.y, dir.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.Euler(0, 0, angle);

        timer += Time.deltaTime;
        if (timer >= coolDown)
        {
            timer = coolDown;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (timer == coolDown)
            {
                canShoot = true;
            }


        }
        else
        {
            canShoot = false;
        }

        if (canShoot == true)
        {
            Instantiate(spearPrefab, firingPoint.position, firingPoint.rotation);
            timer = 0;
        }

    }





}
