using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : SpaceObject
{
    public LevelCompleter m_LevelCompleter;
    private AsteroidCreator asteroidCreator;
    private List<Asteroid> preparedAsteroids = new List<Asteroid>();
    protected override void Start()
    {
        base.Start();
        {
            base.Start();
            asteroidCreator = GetComponent<AsteroidCreator>();
            preparedAsteroids = asteroidCreator.PrepareAsteroids(m_RotateTarget);
        }
    }

    protected override void Explode()
    {
        foreach (Asteroid asteroid in preparedAsteroids)
        {
            asteroid.gameObject.SetActive(true);
            asteroid.AddActionOnDestroyed(m_LevelCompleter.GetDestroyedAsteroidCallback());
        }
        m_LevelCompleter.InitializeLevel(preparedAsteroids.Count);
        this.gameObject.SetActive(false);
        //base.Explode();
    }
}
