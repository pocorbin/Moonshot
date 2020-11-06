﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : SpaceObject
{
    private const string SPAWN_TRIGGER = "Spawn";
    private const string DESPAWN_TRIGGER = "Despawn";
    public LevelCompleter m_LevelCompleter;
    private AsteroidCreator asteroidCreator;
    private List<Asteroid> preparedAsteroids = new List<Asteroid>();

    private Animator mAnimator;

    private bool isInitialized = false;
    protected override void Start()
    {
        base.Start();
        {
            base.Start();
        }
    }

    private void Initialize()
    {
        if (!isInitialized)
        {
            isInitialized = true;
            mAnimator = GetComponent<Animator>();
            asteroidCreator = GetComponent<AsteroidCreator>();
            mAnimator = GetComponent<Animator>();
        }
        preparedAsteroids = asteroidCreator.PrepareAsteroids(m_RotateTarget);
    }

    protected override void Explode()
    {
        PlayExplosionFX();
        foreach (Asteroid asteroid in preparedAsteroids)
        {
            asteroid.gameObject.SetActive(true);
            asteroid.AddActionOnDestroyed(m_LevelCompleter.GetDestroyedAsteroidCallback());
        }
        m_LevelCompleter.InitializeLevel(preparedAsteroids.Count);
        mAnimator.SetTrigger(DESPAWN_TRIGGER);
        //base.Explode();
    }

    public void Spawn()
    {
        Initialize();
        mAnimator.SetTrigger(SPAWN_TRIGGER);
    }
}
