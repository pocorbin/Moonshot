using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Asteroid : SpaceObject
{
    private Action<Asteroid> onAsteroidDestroyedAction;
    public float remainingPointBudget = 0f; //Used during preparation
    private float pointValue = 0f; //Will be used for score

    override protected void Start()
    {
        pointValue = AsteroidCreator.BASE_ASTEROID_COST;
        base.Start();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == Earth.EARTH_TAG)
        {
            Earth collidedEarth = collision.gameObject.GetComponent<Earth>();
            collidedEarth.ReceiveDamage();
            this.Explode();
        }
    }

    public void AddActionOnDestroyed(Action<Asteroid> pCallback)
    {
        onAsteroidDestroyedAction += pCallback;
    }

    override protected void Explode()
    {
        onAsteroidDestroyedAction(this);
        base.Explode();
    }

    public void IncreasePointValue(float pointIncrease)
    {
        pointValue += pointIncrease;
    }
}
