using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : SpaceObject
{
    public ParticleSystem m_ExplosionEffect;

    protected override void Explode()
    {
        Instantiate(m_ExplosionEffect,this.transform.position, m_ExplosionEffect.transform.rotation, this.transform.parent);
        base.Explode();
    }
}
