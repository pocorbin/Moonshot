using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    private const int DISTANCE_TO_DESTROY = 20;
    public int m_Damage = 1;

    private Action missCallback;
    private Action hitCallback;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistanceFromOrigin();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == Asteroid.ASTEROID_TAG)
        {
            Asteroid collidedAsteroid = collision.gameObject.GetComponent<Asteroid>();
            collidedAsteroid.ReceiveDamage(m_Damage);
            hitCallback();
            Destroy(this.gameObject);
        } else if (collision.gameObject.tag == Moon.MOON_TAG)
        {
            Moon collidedMoon = collision.gameObject.GetComponent<Moon>();
            collidedMoon.ReceiveDamage(m_Damage);
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
}
