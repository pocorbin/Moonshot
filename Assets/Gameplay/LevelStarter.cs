using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public Moon m_Moon;
    private Earth earth;
    private LevelCompleter levelCompleter;
    public StatsTracker m_StatsTracker;
    public int m_PointBudgetForFirstLevel = 100;
    private float pointBudgetForCurrentLevel = 0;
    public float m_PointBudgetPercentIncrease = 30f;
    // Start is called before the first frame update
    void Start()
    {
        levelCompleter = GetComponent<LevelCompleter>();
        earth = GetComponent<Earth>();
        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel()
    {
        CalculatePointBudgetForLevel();
        m_Moon.Spawn(levelCompleter.GetCurrentLevel());
        if(earth.IsDestroyed())
        {
            m_StatsTracker.ResetStats();
            earth.Spawn();
        }
    }

    private void CalculatePointBudgetForLevel()
    {
        if(levelCompleter.GetCurrentLevel() == 0)
        {
            //reset point budget
            pointBudgetForCurrentLevel = m_PointBudgetForFirstLevel;
        } else
        {
            float percentIncrease = m_PointBudgetPercentIncrease / 100f;
            pointBudgetForCurrentLevel = pointBudgetForCurrentLevel + (levelCompleter.GetCurrentLevel() * percentIncrease);
        }
    }
}
