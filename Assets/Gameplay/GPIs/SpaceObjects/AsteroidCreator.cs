using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreator : MonoBehaviour
{
    public static float BASE_ASTEROID_COST = 20f;
    public Asteroid m_AsteroidPrefab;

    [Header("Asteroid Randomization")]
    public PointAccountant m_PointAccountant;
    public int m_MinAsteroidSpeed = 1;
    public int m_MaxAsteroidSpeed = 200;

    public float m_AsteroidMinStartDistance = 2;
    public float m_AsteroidMaxStartDistance = 6;

    public List<Asteroid> PrepareAsteroids(Transform rotateTarget)
    {
        List<Asteroid> preparedAsteroids = new List<Asteroid>();
        /*for (int i = 0; i < m_AsteroidsToSpawn; i++)
        {
            Asteroid temp = Instantiate(m_AsteroidPrefab);
            temp.m_RotateTarget = rotateTarget;
            temp.gameObject.SetActive(false);
            RandomizeAsteroidProperties(temp);
            preparedAsteroids.Add(temp);
        }*/
        while(m_PointAccountant.Spend(BASE_ASTEROID_COST))
        {
            Asteroid temp = Instantiate(m_AsteroidPrefab);
            temp.m_RotateTarget = rotateTarget;
            temp.gameObject.SetActive(false);
            temp.remainingPointBudget = m_PointAccountant.GetAsteroidPointBudget();
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
        /*int rotationSpeed = Random.Range(m_MinAsteroidSpeed, m_MaxAsteroidSpeed);
        if (Random.Range(0, 2) == 1)
        {
            rotationSpeed = rotationSpeed * -1;
        }
        asteroid.m_BaseRotationSpeed = rotationSpeed;*/

        float rotationSpeed = m_PointAccountant.GetMinSpeedValue();
        int numberOfPurchases = Random.Range(0, m_PointAccountant.GetMaximumPossibleSpeedPurchases(asteroid.remainingPointBudget));
        for(int i = 0; i < numberOfPurchases; i++)
        {
            if(m_PointAccountant.Spend(m_PointAccountant.GetSpeedCost()))
            {
                rotationSpeed++;
                asteroid.remainingPointBudget -= m_PointAccountant.GetSpeedCost();
            }
        }


        float debugFloat = rotationSpeed - m_PointAccountant.GetMinSpeedValue();
        debugFloat = debugFloat * m_PointAccountant.GetSpeedCost();
        Debug.Log("Spent " + debugFloat + " points on speed to reach " + rotationSpeed);
        //Randomize direction
        if (Random.Range(0, 2) == 1)
        {
            rotationSpeed = rotationSpeed * -1;
        }
        asteroid.m_BaseRotationSpeed = rotationSpeed;
    }

    private void RandomizeAsteroidStartPosition(Asteroid asteroid)
    {
        float altitude = Random.Range(m_AsteroidMinStartDistance, m_AsteroidMaxStartDistance);
        asteroid.transform.position = new Vector3(0, altitude,0);
    }
}
