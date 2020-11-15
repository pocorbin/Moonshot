using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreator : MonoBehaviour
{
    public static float BASE_ASTEROID_COST = 20f;
    public Asteroid m_AsteroidPrefab;

    [Header("Asteroid Randomization")]
    public PointAccountant m_PointAccountant;

    public float m_AsteroidMinStartDistance = 2;
    public float m_AsteroidMaxStartDistance = 6;

    public List<Asteroid> PrepareAsteroids(Transform rotateTarget)
    {
        List<Asteroid> preparedAsteroids = new List<Asteroid>();
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
        RandomizeAsteroidAltitude(asteroid);
    }

    private void RandomizeAsteroidSpeed(Asteroid asteroid)
    {
        float rotationSpeed = m_PointAccountant.GetMinSpeedValue();
        int numberOfPurchases = Random.Range(0, m_PointAccountant.GetMaximumPossibleSpeedPurchases(asteroid.remainingPointBudget));
        for(int i = 0; i < numberOfPurchases; i++)
        {
            if(m_PointAccountant.Spend(m_PointAccountant.GetSpeedCost()))
            {
                rotationSpeed += m_PointAccountant.GetSpeedIncrementRate();
                asteroid.remainingPointBudget -= m_PointAccountant.GetSpeedCost();
            }
        }
        //Randomize direction
        if (Random.Range(0, 2) == 1)
        {
            rotationSpeed = rotationSpeed * -1;
        }
        asteroid.m_BaseRotationSpeed = rotationSpeed;
    }

    private void RandomizeAsteroidAltitude(Asteroid asteroid)
    {
        //float altitude = Random.Range(m_AsteroidMinStartDistance, m_AsteroidMaxStartDistance);
        //asteroid.transform.position = new Vector3(0, altitude,0);

        float altitude = m_PointAccountant.GetMaxAltitudeValue();
        int numberOfPurchases = Random.Range(0, m_PointAccountant.GetMaximumPossibleAltitudePurchases(asteroid.remainingPointBudget));
        float totalPointsSpent = 0f;
        for (int i = 0; i < numberOfPurchases; i++)
        {
            if (m_PointAccountant.Spend(m_PointAccountant.GetAltitudeCost()))
            {
                altitude -= m_PointAccountant.GetAltitudeIncrementRate();
                asteroid.remainingPointBudget -= m_PointAccountant.GetAltitudeCost();
                totalPointsSpent += m_PointAccountant.GetAltitudeCost();
            }
        }
        Debug.Log("Spent " + totalPointsSpent + " points on altitude to reach " + altitude);
        asteroid.transform.position = new Vector3(0, altitude, 0);
    }
}
