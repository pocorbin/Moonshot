using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAccountant : MonoBehaviour
{
    public int m_PointBudgetForFirstLevel = 100;
    private float pointBudgetForCurrentLevel = 0;
    private float pointsLeftForCurrentLevel = 0;
    public float m_PointBudgetPercentIncrease = 30f;
    private int currentLevel = 0;
    public DifficultyBudget m_AsteroidBudget;
    public DifficultyBudget m_SpeedBudget;
    public DifficultyBudget m_AltitudeBudget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PreparePointBudget(int pCurrentLevel) //0 based
    {
        currentLevel = pCurrentLevel;
        Debug.Log("********");
        Debug.Log("Level " + currentLevel + " started");
        CalculatePointBudgetForLevel();
        Debug.Log("Budget is " + pointsLeftForCurrentLevel + " points");
    }

    private void CalculatePointBudgetForLevel()
    {
        if (currentLevel == 0)
        {
            //reset point budget
            pointBudgetForCurrentLevel = m_PointBudgetForFirstLevel;
        }
        else
        {
            float percentIncrease = m_PointBudgetPercentIncrease / 100f;
            pointBudgetForCurrentLevel = pointBudgetForCurrentLevel + (pointBudgetForCurrentLevel * percentIncrease);
        }
        pointsLeftForCurrentLevel = pointBudgetForCurrentLevel;
    }

    public bool Spend(float points)
    {
        bool couldSpend = false;

        if(points <= pointsLeftForCurrentLevel)
        {
            pointsLeftForCurrentLevel -= points;
            couldSpend = true;
        }

        return couldSpend;
    }

    public float GetAsteroidPointBudget()
    {
        return m_AsteroidBudget.GetMaxValue(currentLevel);
    }

    public float GetMinSpeedValue()
    {
        return m_SpeedBudget.GetMinValue(currentLevel);
    }

    public float GetMaxSpeedValue()
    {
        return m_SpeedBudget.GetMaxValue(currentLevel);
    }

    public float GetSpeedCost()
    {
        return m_SpeedBudget.cost;
    }

    public float GetSpeedIncrementRate()
    {
        return m_SpeedBudget.incrementRate;
    }

    //This considers the maximum number of purchases given the min and max value, as well as the asteroid budget.
    //This DOES NOT take into account the remaining point budgets for the current level
    public int GetMaximumPossibleSpeedPurchases(float remainingAsteroidBudget)
    {
        float difference = m_SpeedBudget.GetMaxValue(currentLevel) - m_SpeedBudget.GetMinValue(currentLevel);
        int maxPossibleSpeedPurchases = Mathf.FloorToInt(difference/m_SpeedBudget.cost);

        int maxPossiblePurchasesWithRemainingBudget = Mathf.FloorToInt(remainingAsteroidBudget / m_SpeedBudget.incrementRate/ m_SpeedBudget.cost);

        maxPossibleSpeedPurchases = Mathf.Min(maxPossibleSpeedPurchases, maxPossiblePurchasesWithRemainingBudget);

        return maxPossibleSpeedPurchases;
    }

    public float GetMinAltitudeValue()
    {
        return m_AltitudeBudget.GetMinValue(currentLevel);
    }

    public float GetMaxAltitudeValue()
    {
        return m_AltitudeBudget.GetMaxValue(currentLevel);
    }

    public float GetAltitudeCost()
    {
        return m_AltitudeBudget.cost;
    }

    public float GetAltitudeIncrementRate()
    {
        return m_AltitudeBudget.incrementRate;
    }

    //This considers the maximum number of purchases given the min and max value, as well as the asteroid budget.
    //This DOES NOT take into account the remaining point budgets for the current level
    public int GetMaximumPossibleAltitudePurchases(float remainingAsteroidBudget)
    {
        float difference = m_AltitudeBudget.GetMaxValue(currentLevel) - m_AltitudeBudget.GetMinValue(currentLevel);
        int maxPossibleAltitudePurchases = Mathf.FloorToInt(difference /m_AltitudeBudget.incrementRate/ m_AltitudeBudget.cost);

        int maxPossiblePurchasesWithRemainingBudget = Mathf.FloorToInt(remainingAsteroidBudget / m_AltitudeBudget.cost);

        maxPossibleAltitudePurchases = Mathf.Min(maxPossibleAltitudePurchases, maxPossiblePurchasesWithRemainingBudget);

        return maxPossibleAltitudePurchases;
    }
}
