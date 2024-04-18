using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    int weaponSelected = 0;

    [SerializeField]
    GameObject Sword, Club, Spear;
    [SerializeField] GameObject swordImg, clubImg, spearImg;
    private bool hasSword = false;
    private bool hasClub = false;
    private bool hasSpear = false;

    //public AudioClip collectSound;

    // Start is called before the first frame update
    void Start()
    {
        weaponSelected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if player has the weapong 
       
      
        
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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword")){
            hasSword = true;
            //todo play collect sound
            // AudioManager.instance.PlaySFX(collectSound);
            // AudioManager.instance.PlaySFX("Collect");
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Club"))
        {
            hasClub = true;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Spear"))
        {
            hasSpear = true;
            Destroy(other.gameObject);
        }
    }
    void SwapWeapon (int weapon)
    {
        if(hasSword == true)
        {
            if (weapon == 1)
            {

                swordImg.SetActive(true);
                clubImg.SetActive(false);
                spearImg.SetActive(false);

                Sword.SetActive(true);
                Club.SetActive(false);
                Spear.SetActive(false);
            }

        }
       
        if (hasClub == true)
        {
           if (weapon == 2)
           {
            swordImg.SetActive(false);
            clubImg.SetActive(true);
            spearImg.SetActive(false);

            Sword.SetActive(false);
            Club.SetActive(true);
            Spear.SetActive(false);
           }
        }
       
        if (hasSpear == true)
        { 
            if (weapon == 3)
           {
            swordImg.SetActive(false);
            clubImg.SetActive(false);
            spearImg.SetActive(true);

            Sword.SetActive(false);
            Club.SetActive(false);
            Spear.SetActive(true);
            } 
        }
       
        if (weapon == 0)
        {
            swordImg.SetActive(false);
            clubImg.SetActive(false);
            spearImg.SetActive(false);

            Sword.SetActive(false);
            Club.SetActive(false);
            Spear.SetActive(false);
        }
        
        AudioManager.instance.PlaySFX("WeaponChange");
    }
    
}
