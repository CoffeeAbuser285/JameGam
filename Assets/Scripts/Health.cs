using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float initialHealth;
    public float damageMultiplier = 1;

    private float m_CurrentHealth;
    private bool m_IsDead;
    private ParticleSystem m_HitPartices;
    private bool m_IsActive;

    public float health
    {
        get => m_CurrentHealth;
        set {
            if (value > 0 && value < initialHealth) {
                m_CurrentHealth = value;
                m_IsDead = false;
            }
        }
    }

    public bool isDead
    {
        get => m_IsDead;
    }

    public bool isActive
    {
        get => m_IsActive;
        set {
            m_IsActive = value;
        }
    }

    void Awake()
    {
        m_HitPartices = GetComponent<ParticleSystem>();
        m_IsActive = true;
    }

    void OnEnable()
    {
        m_CurrentHealth = initialHealth;
        m_IsDead = false;
    }

    public void TakeHit(float ammount) {
        if (!m_IsActive) return;

        m_CurrentHealth -= ammount*damageMultiplier;
        if (m_CurrentHealth <= 0) {
            m_CurrentHealth = 0f;
            m_IsDead = true;
        }
        // Debug.Log(m_CurrentHealth);
    }

    public void TakeHit(float ammount, Vector3 hitPoint) {
        if (!m_IsActive) return;

        if (m_HitPartices != null) {
            m_HitPartices.transform.position = hitPoint;

            m_HitPartices.Stop();
            m_HitPartices.Play();
        }

        TakeHit(ammount);
    }
}
