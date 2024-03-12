using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    int weaponSelected = 0;

    [SerializeField]
    GameObject Sword, Club, Spear;

    // Start is called before the first frame update
    void Start()
    {
        weaponSelected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
       if(Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            if(weaponSelected != 1)
            {
                SwapWeapon(1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
            if (weaponSelected != 2)
            {
                SwapWeapon(2);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (weaponSelected != 3)
            {
                SwapWeapon(3);
            }
        }
    }
    void SwapWeapon (int weapon)
    {
        if( weapon == 1 ) 
        {
            Sword.SetActive(true);
            Club.SetActive(false);
            Spear.SetActive(false);
        }
        if (weapon == 2)
        {
            Sword.SetActive(false);
            Club.SetActive(true);
            Spear.SetActive(false);
        }
        if (weapon == 3)
        {
            Sword.SetActive(false);
            Club.SetActive(false);
            Spear.SetActive(true);
        }
    }
}
