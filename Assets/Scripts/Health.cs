using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject adCanvas; 
    public float initialHealth = 3f;
    public AudioSource healthPickup;
    private float currentHealth = 3f;
    private bool isDead;
    private GameObject canvas;
    private SpriteRenderer[] spriteRenderers;
    private TilemapRenderer[] tilemapRenderers;
    private string[] items = { "Health Boost", "Increased FireRate"};
    private int num = 0;

    public void Start()
    {
        canvas = GameObject.FindWithTag( "Canvas" );

        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        tilemapRenderers = GetComponentsInChildren<TilemapRenderer>();

        spriteRenderers = spriteRenderers.Where(sr => sr.tag != "NoColorChange").ToArray();
        //tilemapRenderers = tilemapRenderers.Where(tr => tr.tag != "NoColorChange").ToArray();
        
        
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

    private IEnumerator UpdateColor()
    {
        // Set all renderers to white
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            sr.color = Color.white;
        }
        foreach (TilemapRenderer tr in tilemapRenderers)
        {
            tr.GetComponent<Tilemap>().color = Color.white;
        }

        // Wait for 0.1 seconds
        yield return new WaitForSeconds(0.1f);


        float healthPercent = currentHealth / initialHealth;
        Color newColor = new Color(1f, Mathf.Lerp(0.5f, 1f, healthPercent), Mathf.Lerp(0.5f, 1f, healthPercent));

        // Apply the color change to all sprites
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            sr.color = newColor;
        }
        
        // Change color of all TilemapRenderers
        foreach (TilemapRenderer tr in tilemapRenderers)
        {
            tr.GetComponent<Tilemap>().color = newColor;
        }
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine( UpdateColor() );
        checkIfDead();

        if ( gameObject.CompareTag("Player") )
        {
            if ( currentHealth > 0 )
            {   
                StartCoroutine( ShowAd() );
            }
            else
            {
                GetComponent<PlayerDead>().SaveData();
                GetComponent<PlayerDead>().DeathLogic();
            }
        }
        
    }

    public bool checkIfDead()
    {   
        if (currentHealth <= 0)
        {
            isDead = true;
        }
        return isDead;
    }

    private IEnumerator ShowAd()
    {   
        yield return null;

        num  = Random.Range(0, 2);
        adCanvas.GetComponent<AddPopup>().ShowAdd( 5f, items[ num ] );
    }

    public void AddHealth( int numHealth )
    {
        currentHealth += numHealth;

        // Play Health Audio
        healthPickup.Play();
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
