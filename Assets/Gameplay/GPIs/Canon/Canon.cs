using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    protected float missileSpeed = 10f;

    public KeyCode m_KeyToPress;

    public Pellet m_PelletPrefab;

    public Vector2 m_Direction = new Vector2(0, 0);

    public ParticleSystem m_MuzzleFlash;

    protected RandomSFXAssigner sfxAssigner;
    protected AudioSource audioSource;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sfxAssigner = GetComponent<RandomSFXAssigner>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CheckShoot();
    }

    protected virtual void CheckShoot()
    {
        if (Input.GetKeyDown(m_KeyToPress))
        {
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        Pellet shotPellet = Instantiate(m_PelletPrefab);
        Rigidbody pelletBody = shotPellet.GetComponent<Rigidbody>();
        pelletBody.velocity = m_Direction * missileSpeed;
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
        sfxAssigner.AssignSFX();
        audioSource.Play();
    }
}
