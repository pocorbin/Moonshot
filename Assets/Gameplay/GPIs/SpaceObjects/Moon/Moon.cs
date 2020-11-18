using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : SpaceObject
{
    private const string SPAWN_TRIGGER = "Spawn";
    private const string DESPAWN_TRIGGER = "Despawn";
    public LevelCompleter m_LevelCompleter;
    public StatsTracker m_StatsTracker;
    public StardustCounter m_StardustCounter;
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
            asteroid.AddActionOnDestroyed(m_StatsTracker.GetDestroyedAsteroidCallback());
        }
        m_LevelCompleter.InitializeLevel(AsteroidListToSpaceObjectList(preparedAsteroids));
        mAnimator.SetTrigger(DESPAWN_TRIGGER);
        //base.Explode();
    }

    private List<SpaceObject> AsteroidListToSpaceObjectList(List<Asteroid> asteroidsToConvert)
    {
        List<SpaceObject> spaceObjects = new List<SpaceObject>();
        foreach(var asteroid in asteroidsToConvert)
        {
            spaceObjects.Add(asteroid);
        }
        return spaceObjects;
    }

    public void Spawn()
    {
        Initialize();
        mAnimator.SetTrigger(SPAWN_TRIGGER);
    }
}
