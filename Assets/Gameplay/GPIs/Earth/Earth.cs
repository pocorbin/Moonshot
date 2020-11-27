using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Earth : MonoBehaviour
{
    public const string EARTH_TAG = "Earth";
    private const string DESTROY_TRIGGER = "Destroy";
    private const string FALL_OFF_TRIGGER = "FallOff";
    private const string SPAWN_TRIGGER = "Spawn";

    private int maxHealth = 1;
    private int health;

    private bool isDestroyed = false;

    private Action OnDestroyed;

    private Animator mAnimator;

    public Shield mShield;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        mAnimator = GetComponent<Animator>();
        mShield.Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReceiveDamage()
    {
        if(mShield.GetHealth()>=1)
        {
            mShield.ReceiveDamage();
        } else
        {
            health--;
            if (health <= 0 && !isDestroyed)
            {
                isDestroyed = true;
                OnDestroyed();
                mAnimator.SetTrigger(DESTROY_TRIGGER);
            }
        }
    }

    public void SetOnDestroyedCallback(Action pCallback)
    {
        OnDestroyed = pCallback;
    }

    public void FallOff()
    {
        mAnimator.SetTrigger(FALL_OFF_TRIGGER);
    }

    public void Spawn()
    {
        isDestroyed = false;
        health = maxHealth;
        mAnimator.SetTrigger(SPAWN_TRIGGER);
        mShield.Initialize();
    }

    public bool IsDestroyed()
    {
        return isDestroyed;
    }
}
