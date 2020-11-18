using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StardustVFX : MonoBehaviour
{
    public const string STARDUST_TAG = "Stardust";

    public float m_Delay = 0.5f;
    private MoveToPositionOverTime mover;
    private TimerManager timerManager;
    private Timer movementDelayTimer;
    private Action startMovingCallback;
    public float value = 0f;
    // Start is called before the first frame update
    void Start()
    {
        startMovingCallback += StartMoving;
        mover = GetComponent<MoveToPositionOverTime>();
        timerManager = GetComponent<TimerManager>();
        movementDelayTimer = timerManager.CreateTimer(m_Delay, false, startMovingCallback);
        movementDelayTimer.Start();
    }

    private void StartMoving()
    {
        mover.enabled = true;
    }
}
