using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public UpgradeObject m_ShieldUpgrade;
    public ParticleSystem m_ShieldHitEffect;
    public ParticleSystem m_ShieldIdleEffect;
    public ParticleSystem m_ShieldDespawnEffect;
    public ShieldCounter m_ShieldCounter;

    private int maxHealth = 1;
    private int health;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveDamage()
    {
        health--;
        m_ShieldHitEffect.Play();
        m_ShieldCounter.LoseCharge();
        if (health <= 0)
        {
            m_ShieldDespawnEffect.Play();
            m_ShieldIdleEffect.Stop();
            m_ShieldIdleEffect.gameObject.SetActive(false);
        }
    }

    public void Initialize()
    {
        if(PlayerPrefs.HasKey(m_ShieldUpgrade.upgradeKey) && PlayerPrefs.GetInt(m_ShieldUpgrade.upgradeKey) > 0)
        {
            maxHealth = PlayerPrefs.GetInt(m_ShieldUpgrade.upgradeKey);
            health = maxHealth;
            m_ShieldIdleEffect.gameObject.SetActive(true);
            m_ShieldIdleEffect.Play();
        }
        m_ShieldCounter.Initialize();
    }

    public int GetHealth()
    {
        return health;
    }
}
