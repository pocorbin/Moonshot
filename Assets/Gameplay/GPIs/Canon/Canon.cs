using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    protected float missileSpeed = 10f;

    public List<KeyCode> m_KeysToPress = new List<KeyCode>();

    public Pellet m_PelletPrefab;

    public Vector2 m_Direction = new Vector2(0, 0);

    public ParticleSystem m_MuzzleFlash;

    public StatsTracker m_StatsTracker;

    protected RandomSFXAssigner sfxAssigner;
    protected AudioSource audioSource;

    protected Action mShootCallback;
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
        for(int i = 0; i <m_KeysToPress.Count; i++)
        {
            if (Input.GetKeyDown(m_KeysToPress[i]))
            {
                Shoot();
            }
        }
    }

    public virtual void Shoot()
    {
        Pellet shotPellet = Instantiate(m_PelletPrefab);
        Rigidbody pelletBody = shotPellet.GetComponent<Rigidbody>();
        pelletBody.velocity = m_Direction * missileSpeed;
        shotPellet.SetMissCallback(m_StatsTracker.GetMissileMissCallback());
        shotPellet.SetMissileHitCallback(m_StatsTracker.GetMissileHitCallback());
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
        mShootCallback?.Invoke();
    }

    public void SetShootCallback(Action pCallback)
    {
        mShootCallback += pCallback;
    }
}
