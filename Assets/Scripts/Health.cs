using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float initialHealth = 3f;
    private float currentHealth = 3f;
    private bool isDead;
    private GameObject canvas;

    public void Start()
    {
        canvas = GameObject.FindWithTag( "Canvas" );
        currentHealth = initialHealth;
        isDead = false;
    }
    
    public void Update()
    {
        if ( isDead == true )
        {
            // Incrementing score on enemy or player death (yes, player death)
            // Score is based on enemy health
            canvas.GetComponent<UiManager>().AddScore( Mathf.FloorToInt(initialHealth ) );

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
