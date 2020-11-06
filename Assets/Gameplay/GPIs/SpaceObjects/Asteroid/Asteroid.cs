using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Asteroid : SpaceObject
{
    private Action<Asteroid> onAsteroidDestroyedAction;
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
}
