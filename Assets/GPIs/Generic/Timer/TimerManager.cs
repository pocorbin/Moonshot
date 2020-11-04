using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerManager :MonoBehaviour
{
    private List<Timer> timers = new List<Timer>();
    private void Start()
    {
        
    }

    private void Update()
    {
        IncrementTimers();
    }

    private void IncrementTimers()
    {
        foreach(var timer in timers)
        {
            timer.IncrementTime(Time.deltaTime);
        }
    }

    public Timer CreateTimer()
    {
        return this.CreateTimer(0f, false, null);
    }

    public Timer CreateTimer(float pTimeBeforeEnd)
    {
        return this.CreateTimer(pTimeBeforeEnd, false, null);
    }

    public Timer CreateTimer(float pTimeBeforeEnd, bool pAutoRestart)
    {
        return this.CreateTimer(pTimeBeforeEnd, pAutoRestart, null);
    }

    public Timer CreateTimer(float pTimeBeforeEnd, Action pCallback)
    {
        return this.CreateTimer(pTimeBeforeEnd, false, pCallback);
    }

    public Timer CreateTimer(float pTimeBeforeEnd, bool pAutoRestart, Action pCallback)
    {
        Timer createdTimer = new Timer(pTimeBeforeEnd, pAutoRestart, pCallback);
        timers.Add(createdTimer);
        return createdTimer;
    }

    public void DestroyAllTimers()
    {
        timers.Clear();
    }
}
