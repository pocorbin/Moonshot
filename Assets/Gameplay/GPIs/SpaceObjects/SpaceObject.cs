﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpaceObject : MonoBehaviour
{
    public const string ASTEROID_TAG = "Asteroid";
    public const string MOON_TAG = "Moon";

    private const float CRASH_SPEED_MULTIPLIER = 1.01f;

    [Header("Space Object")]
    public Transform m_RotateTarget;
    public float m_TargetAttraction = 1f;

    public int m_MaxHealth = 1;
    public float m_BaseRotationSpeed = 40f;
    public float m_DistanceCoefficient = 1f; //Raise this to make the asteroid rotate faster the closer it is to its target
    public ParticleSystem m_ExplosionEffect;

    private int currentHealth = 0;

    protected bool acceleratingToCrash = false;

    private Action onSpaceObjectDestroyedAction;

    protected bool canBeDestroyedByPlayer = true;

    virtual protected void Start()
    {
        currentHealth = m_MaxHealth;
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        MoveTowardsTarget();
        RotateAroundTarget();
        AccelerateToCrash();
    }

    virtual protected void MoveTowardsTarget()
    {
        float distanceFromTarget = Vector3.Distance(this.transform.position, m_RotateTarget.position);
        float newAttractionSpeed = m_TargetAttraction;
        if (distanceFromTarget != 0)
        {
            newAttractionSpeed = m_TargetAttraction / distanceFromTarget * m_DistanceCoefficient;
        }
        transform.position = Vector3.MoveTowards(this.transform.position, m_RotateTarget.position, newAttractionSpeed * (Time.deltaTime / 10));
    }

    virtual protected void RotateAroundTarget()
    {
        float distanceFromTarget = Vector3.Distance(this.transform.position, m_RotateTarget.position);
        float newRotationSpeed = m_BaseRotationSpeed;
        if (distanceFromTarget != 0)
        {
            newRotationSpeed = m_BaseRotationSpeed / distanceFromTarget * m_DistanceCoefficient;
        }
        transform.RotateAround(m_RotateTarget.position, Vector3.forward, newRotationSpeed * Time.deltaTime);
    }

    virtual public void ReceiveDamage(int receivedDamage)
    {
        currentHealth -= receivedDamage;
        CheckExplosion();
    }

    virtual protected void CheckExplosion()
    {
        if (currentHealth <= 0)
        {
            Explode();
        }
    }

    virtual protected void Explode()
    {
        PlayExplosionFX();
        if(canBeDestroyedByPlayer)
        {
            onSpaceObjectDestroyedAction();
        }
        GameObject.Destroy(this.gameObject);
    }

    virtual protected void PlayExplosionFX()
    {
        Instantiate(m_ExplosionEffect, this.transform.position, m_ExplosionEffect.transform.rotation, this.transform.parent);
    }

    public void CrashIntoTarget()
    {
        acceleratingToCrash = true;
        canBeDestroyedByPlayer = false;
    }

    private void AccelerateToCrash()
    {
        if(acceleratingToCrash)
        {
            m_DistanceCoefficient = Mathf.Min(m_DistanceCoefficient * CRASH_SPEED_MULTIPLIER, 10);
            m_TargetAttraction = Mathf.Min(m_TargetAttraction * CRASH_SPEED_MULTIPLIER,16);
        }
    }

    public void AddActionOnDestroyed(Action pCallback)
    {
        onSpaceObjectDestroyedAction += pCallback;
    }
}
