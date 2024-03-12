using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("HIT");
            // Deal damage to the enemy
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Health -= damage;
            }
        }
    }
}
