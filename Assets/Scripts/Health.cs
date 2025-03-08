using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float initialHealth = 3;
    public float currentHealth;
    public bool isDead;

    public void Start()
    {
        currentHealth = initialHealth;
        isDead = false;
    }
    
    public void Update()
    {
        if ( isDead == true )
        {
            // Destroying self if dead
            Destroy( gameObject );
        }
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        checkIfDead();
    }

    public bool checkIfDead()
    {   
        if (currentHealth <= 0)
        {
            isDead = true;
        }

        return isDead;
    }

}
