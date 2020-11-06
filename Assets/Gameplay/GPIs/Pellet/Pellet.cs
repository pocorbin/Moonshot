using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int m_Damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == Asteroid.ASTEROID_TAG)
        {
            Asteroid collidedAsteroid = collision.gameObject.GetComponent<Asteroid>();
            collidedAsteroid.ReceiveDamage(m_Damage);
            Destroy(this.gameObject);
        } else if (collision.gameObject.tag == Moon.MOON_TAG)
        {
            Moon collidedMoon = collision.gameObject.GetComponent<Moon>();
            collidedMoon.ReceiveDamage(m_Damage);
            Destroy(this.gameObject);
        }
    }
}
