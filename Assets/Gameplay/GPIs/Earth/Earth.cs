using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Earth : MonoBehaviour
{
    public const string EARTH_TAG = "Earth";

    private int maxHealth = 1;
    private int health;

    private bool isDestroyed = false;

    private Action OnDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReceiveDamage()
    {
        health--;
        if(health <= 0 && !isDestroyed)
        {
            isDestroyed = true;
            OnDestroyed();
        }
    }

    public void SetOnDestroyedCallback(Action pCallback)
    {
        OnDestroyed = pCallback;
    }
}
