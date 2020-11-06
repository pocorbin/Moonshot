using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : SpaceObject
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == Earth.EARTH_TAG)
        {
            Earth collidedEarth = collision.gameObject.GetComponent<Earth>();
            collidedEarth.ReceiveDamage();
            this.Explode();
        }
    }
}
