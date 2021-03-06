﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public Moon m_Moon;
    private Earth earth;
    private LevelCompleter levelCompleter;
    public StatsTracker m_StatsTracker;
    public PointAccountant m_PointAccountant;
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
        m_PointAccountant.PreparePointBudget(levelCompleter.GetCurrentLevel());
        m_Moon.Spawn();
        if(earth.IsDestroyed())
        {
            m_StatsTracker.ResetStats();
            earth.Spawn();
        }
    }

}
