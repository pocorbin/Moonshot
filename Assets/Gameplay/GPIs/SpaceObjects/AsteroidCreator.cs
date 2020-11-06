using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreator : MonoBehaviour
{
    public Asteroid m_AsteroidPrefab;

    public int m_AsteroidsToSpawn = 3;

    [Header("Asteroid Randomization")]
    public int m_MinAsteroidSpeed = 1;
    public int m_MaxAsteroidSpeed = 200;

    public float m_AsteroidMinStartDistance = 2;
    public float m_AsteroidMaxStartDistance = 6;

    public List<Asteroid> PrepareAsteroids(Transform rotateTarget)
    {
        List<Asteroid> preparedAsteroids = new List<Asteroid>();
        for (int i = 0; i < m_AsteroidsToSpawn; i++)
        {
            Asteroid temp = Instantiate(m_AsteroidPrefab);
            temp.m_RotateTarget = rotateTarget;
            temp.gameObject.SetActive(false);
            RandomizeAsteroidProperties(temp);
            preparedAsteroids.Add(temp);
        }
        return preparedAsteroids;
    }

    private void RandomizeAsteroidProperties(Asteroid asteroid)
    {
        RandomizeAsteroidSpeed(asteroid);
        RandomizeAsteroidStartPosition(asteroid);
    }

    private void RandomizeAsteroidSpeed(Asteroid asteroid)
    {
        int rotationSpeed = Random.Range(m_MinAsteroidSpeed, m_MaxAsteroidSpeed);
        if (Random.Range(0, 2) == 1)
        {
            rotationSpeed = rotationSpeed * -1;
        }
        asteroid.m_BaseRotationSpeed = rotationSpeed;
    }

    private void RandomizeAsteroidStartPosition(Asteroid asteroid)
    {
        float altitude = Random.Range(m_AsteroidMinStartDistance, m_AsteroidMaxStartDistance);
        asteroid.transform.position = new Vector2(0, altitude);
    }
}
