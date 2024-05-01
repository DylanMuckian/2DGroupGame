using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private float meleeSpeed;
    public AudioSource source;
    public AudioClip clip;


    //public GameObject sword;

    float timeUnitilMelee;

    SpriteRenderer sr;
    private void Update()
    {
       
        if (timeUnitilMelee <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float angle = Mathf.Atan2(dir.y - transform.position.y, dir.x - transform.position.x) * Mathf.Rad2Deg - 90f;
                transform.localRotation = Quaternion.Euler(0, 0, angle); 
                anim.SetTrigger("Attack");
                
                timeUnitilMelee = meleeSpeed;
                return;
            }    
        } else{
        
            timeUnitilMelee -= Time.deltaTime;
        }

    }
    public void swing()
    {
        source.PlayOneShot(clip);
    }

}
