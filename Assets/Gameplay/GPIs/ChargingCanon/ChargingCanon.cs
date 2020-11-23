using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ChargingCanon : Canon
{
    private bool hasStartedCharging = false;
    private bool isShotReady = false;

    public float secondsBeforeShotIsReady = 0.4f;


    [Header("Effects")]
    public ParticleSystem m_ChargingEffect;
    public ParticleSystem m_ChargingFailedEffect;
    public ParticleSystem m_ChargingCompleteEffect;
    public ParticleSystem m_ChargingCompleteEffectLoop;

    public ChargingOverlay m_ChargingOverlay;

    private TimerManager timerManager;

    private Action readyShot;

    private Timer chargingTimer;

    private AudioSource mChargingClip;
    private AudioSource mChargingFailedClip;
    private RandomSFXAssigner mRandomChargingSFXAssigner;

    protected override void Start()
    {
        missileSpeed = 15f;
        timerManager = GetComponent<TimerManager>();
        readyShot += ReadyShot;
        mChargingClip = m_ChargingEffect.GetComponent<AudioSource>();
        mChargingFailedClip = m_ChargingFailedEffect.GetComponent<AudioSource>();
        mRandomChargingSFXAssigner = mChargingFailedClip.GetComponent<RandomSFXAssigner>();
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
        for (int i = 0; i < m_KeysToPress.Count; i++)
        {
            if (Input.GetKeyDown(m_KeysToPress[i]))
            {
                KeyDown();
            }
        }
    }

    private void CheckRelease()
    {
        if(hasStartedCharging)
        {

            for (int i = 0; i < m_KeysToPress.Count; i++)
            {
                if (Input.GetKeyUp(m_KeysToPress[i]))
                {
                    KeyUp();
                }
            }
        }
    }

    public void KeyDown()
    {
        StartCharging();
    }

    public void KeyUp()
    {
        hasStartedCharging = false;
        if (isShotReady)
        {
            isShotReady = false;
            Shoot();
        }
        else
        {
            FailCharge();
        }
    }

    public override void Shoot()
    {
        base.Shoot();
        m_ChargingOverlay.StopFilling();
        if(m_ChargingCompleteEffectLoop.isPlaying)
        {
            m_ChargingCompleteEffectLoop.Stop();
        }
    }

    private void StartCharging()
    {
        if(!hasStartedCharging)
        {
            timerManager.DestroyAllTimers();
            chargingTimer = timerManager.CreateTimer(secondsBeforeShotIsReady, readyShot);
            chargingTimer.Start();
            m_ChargingOverlay.SetTimerToTrack(chargingTimer);
            hasStartedCharging = true;
            m_ChargingEffect.Play();
            mChargingClip.Play();
        }
    }

    private void FailCharge()
    {
        chargingTimer.Stop();
        m_ChargingEffect.Stop();
        m_ChargingCompleteEffectLoop.Stop();
        m_ChargingFailedEffect.Play();
        mRandomChargingSFXAssigner.AssignSFX();
        mChargingFailedClip.Play();
        mChargingClip.Stop();
        m_ChargingOverlay.StopFilling();
    }

    private void ReadyShot()
    {
        isShotReady = true;
        m_ChargingEffect.Stop();
        m_ChargingCompleteEffect.Play();
        m_ChargingCompleteEffectLoop.Play();
    }
}
