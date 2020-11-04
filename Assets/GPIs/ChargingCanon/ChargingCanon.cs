using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChargingCanon : Canon
{
    private bool hasStartedCharging = false;
    private bool isShotReady = false;

    public float secondsBeforeShotIsReady = 1.5f;

    private TimerManager timerManager;

    public Action readyShot;

    protected override void Start()
    {
        timerManager = GetComponent<TimerManager>();
        readyShot += ReadyShot;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        CheckRelease();
    }

    protected override void CheckShoot()
    {
        if (Input.GetKeyDown(m_KeyToPress))
        {
            StartCharging();
        }
    }

    private void CheckRelease()
    {
        if(hasStartedCharging)
        {
            if(Input.GetKeyUp(m_KeyToPress))
            {
                hasStartedCharging = false;
                if(isShotReady)
                {
                    isShotReady = false;
                    Shoot();
                }
            }
        }
    }

    private void StartCharging()
    {
        if(!hasStartedCharging)
        {
            timerManager.DestroyAllTimers();
            Timer timer = timerManager.CreateTimer(secondsBeforeShotIsReady, readyShot);
            timer.Start();
            hasStartedCharging = true;
        }
    }

    public void ReadyShot()
    {
        Debug.Log("Shot is ready!");
        isShotReady = true;
    }
}
