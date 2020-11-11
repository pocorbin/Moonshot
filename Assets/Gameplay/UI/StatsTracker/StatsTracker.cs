using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsTracker : MonoBehaviour
{
    private Action mIncrementDestroyedAsteroids;
    private Action mIncrementHits;
    private Action mIncrementMisses;

    public Text m_NumberOfAsteroidsDestroyedStat;
    public Text m_AccuracyStat;
    public Text m_LongestHitStreakStat;

    private int destroyedAsteroids = 0;
    private float hits = 0;
    private float misses = 0;
    private int longestStreak = 0;
    private int currentStreak = 0;

    // Start is called before the first frame update
    void Start()
    {
        mIncrementDestroyedAsteroids += IncrementDestroyedAsteroids;
        mIncrementHits += IncrementHits;
        mIncrementMisses += IncrementMisses;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void IncrementDestroyedAsteroids()
    {
        destroyedAsteroids++;
        UpdateDestroyedAsteroids();
    }

    private void IncrementHits()
    {
        hits++;
        currentStreak++;
        UpdateAccuracy();
        UpdateLongestStreak();
        
    }
    private void IncrementMisses()
    {
        misses++;
        currentStreak = 0;
        UpdateAccuracy();
    }

    private void UpdateDestroyedAsteroids()
    {
        m_NumberOfAsteroidsDestroyedStat.text = destroyedAsteroids.ToString();
    }

    private void UpdateAccuracy()
    {
        if(hits > 0)
        {
            float accuracy = hits / (hits + misses) * 100;
            accuracy = Mathf.Round(accuracy);
            m_AccuracyStat.text = accuracy.ToString() + "%";
        } else
        {
            m_AccuracyStat.text = "100%";
        }
    }

    private void UpdateLongestStreak()
    {
        if(currentStreak>longestStreak)
        {
            longestStreak = currentStreak;
            m_LongestHitStreakStat.text = longestStreak.ToString();
        }
    }

    public Action GetDestroyedAsteroidCallback()
    {
        return mIncrementDestroyedAsteroids;
    }
    public Action GetShotFiredCallback()
    {
        return mIncrementDestroyedAsteroids;
    }
    public Action GetMissileHitCallback()
    {
        return mIncrementHits;
    }
    public Action GetMissileMissCallback()
    {
        return mIncrementMisses;
    }
    public void ResetStats()
    {
        destroyedAsteroids = 0;
        hits = 0;
        misses = 0;
        longestStreak = 0;
        currentStreak = 0;
        UpdateDestroyedAsteroids();
        UpdateAccuracy();
        UpdateLongestStreak();
    }
}
