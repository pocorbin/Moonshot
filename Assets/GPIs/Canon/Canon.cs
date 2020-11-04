using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    private const float SPEED = 10f;

    public Pellet m_PelletPrefab;

    public Vector2 m_Direction = new Vector2(0, 0);

    public ParticleSystem m_MuzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {
        Pellet shotPellet = Instantiate(m_PelletPrefab);
        Rigidbody pelletBody = shotPellet.GetComponent<Rigidbody>();
        pelletBody.velocity = m_Direction * SPEED;
        if(m_Direction.x < 0)
        {
            shotPellet.transform.Rotate(0, 0, 90);
        } else if (m_Direction.x > 0)
        {
            shotPellet.transform.Rotate(0, 0, -90);
        } else if (m_Direction.y < 0)
        {
            shotPellet.transform.Rotate(0, 0, 180);
        }
        m_MuzzleFlash.Play();
    }
}
