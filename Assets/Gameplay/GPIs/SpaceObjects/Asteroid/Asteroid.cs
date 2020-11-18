using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Asteroid : SpaceObject
{
    private Action<Asteroid> onAsteroidDestroyedAction;
    public float remainingPointBudget = 0f; //Used during preparation
    public GameObject m_StardustEffect;
    private float pointValue = 0f; //Will be used for score

    override protected void Start()
    {
        pointValue += AsteroidCreator.BASE_ASTEROID_COST;
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
        SpawnStardust();
        onAsteroidDestroyedAction(this);
        Debug.Log("This asteroid was worth " + pointValue + " points!");
        base.Explode();
    }

    private void SpawnStardust()
    {

        GameObject stardustObject = Instantiate(m_StardustEffect, this.transform.position, m_StardustEffect.transform.rotation, this.transform.parent);
        Stardust stardust = stardustObject.GetComponent<Stardust>();
        stardust.value = this.pointValue;
    }

    public void IncreasePointValue(float pointIncrease)
    {
        pointValue += pointIncrease;
        remainingPointBudget -= pointIncrease;
    }

    public float GetPointValue()
    {
        return pointValue;
    }
}
