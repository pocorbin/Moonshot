using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public const string PIERCING_MISSILES_UPGRADE_KEY = "PiercingMissiles";
    private const int DISTANCE_TO_DESTROY = 20;
    public int m_Damage = 1;
    public ParticleSystem m_PropulsionEffect;

    private Action missCallback;
    private Action hitCallback;

    private int mNumberOfPiercesLeft = 0;

    private Collider mCollider;
    // Start is called before the first frame update
    void Start()
    {
        mCollider = GetComponent<Collider>();
        if (PlayerPrefs.HasKey(PIERCING_MISSILES_UPGRADE_KEY))
        {
            mNumberOfPiercesLeft = PlayerPrefs.GetInt(PIERCING_MISSILES_UPGRADE_KEY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistanceFromOrigin();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Asteroid.ASTEROID_TAG)
        {
            Asteroid collidedAsteroid = other.gameObject.GetComponent<Asteroid>();
            collidedAsteroid.ReceiveDamage(m_Damage);
            hitCallback();
            if (mNumberOfPiercesLeft == 0)
            {
                PutPropulsionEffectForAdoption();
                Destroy(this.gameObject);
            }
            else
            {
                mNumberOfPiercesLeft--;
            }
        }
        else if (other.gameObject.tag == Moon.MOON_TAG)
        {
            Moon collidedMoon = other.gameObject.GetComponent<Moon>();
            collidedMoon.ReceiveDamage(m_Damage);
            PutPropulsionEffectForAdoption();
            Destroy(this.gameObject);
        }
    }

    public void SetMissCallback(Action pMissCallback)
    {
        missCallback += pMissCallback;
    }

    public void SetMissileHitCallback(Action pHitCallback)
    {
        hitCallback += pHitCallback;
    }

    private void CheckDistanceFromOrigin()
    {
        if (Vector2.Distance(this.transform.position, Vector2.zero) > DISTANCE_TO_DESTROY)
        {
            missCallback();
            Destroy(this.gameObject);
        }
    }

    private void PutPropulsionEffectForAdoption()
    {
        if (m_PropulsionEffect != null)
        {
            m_PropulsionEffect.transform.parent =  this.transform.parent;
            m_PropulsionEffect.Stop();
        }
    }
}
