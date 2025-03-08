using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float initialHealth = 3f;
    private float currentHealth = 3f;
    private bool isDead;

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

    public float getCurrentHealth()
    {
        return currentHealth;
    }

    public float getInitialHealth()
    {
        return initialHealth;
    }

    public void setInitialHealth( float initHealth )
    {
        initialHealth = initHealth;
    }

    public bool getIsDead()
    {
        return isDead;
    }

}
