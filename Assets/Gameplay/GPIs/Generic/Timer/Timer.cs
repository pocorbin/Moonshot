using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer
{
    private float mCurrentTime = 0f;
    private float mTimeBeforeEnd = 0f;

    private bool mIsRunning = false;

    private bool mAutoRestart = false;

    private bool mIsStopwatch = false;

    private Action mCallback;

    public Timer(float pTimeBeforeEnd, bool pAutoRestart, Action pCallback): base()
    {
        if (pTimeBeforeEnd < 0)
        {
            Debug.LogError("Timer delay must be a positive value");
        }
        else if (pTimeBeforeEnd == 0)
        {
            mIsStopwatch = true;
        }
        else
        {
            mTimeBeforeEnd = pTimeBeforeEnd;
        }
        mCallback = pCallback;
        mAutoRestart = pAutoRestart;
    }

    public void IncrementTime(float pDeltaTime)
    {
        if (mIsRunning)
        {
            mCurrentTime += pDeltaTime;
            CheckEnd();
        }
    }

    private void CheckEnd()
    {
        if (mCurrentTime >= mTimeBeforeEnd && !mIsStopwatch)
        {
            InvokeCallback();
            if (!mAutoRestart)
            {
                Stop();
            }
            else if (mIsRunning)
            {
                Restart();
            }
        }
    }

    private void InvokeCallback()
    {
        if (mCallback != null && mCallback.Target != null)
        {
            try
            {
                mCallback();

            }
            catch (Exception e)
            {
                Debug.LogError(e.Message + " " + mCallback.Method.ToString());
            }
        }
    }

    public void Start()
    {
        mIsRunning = true;
    }

    public void Pause()
    {
        mIsRunning = false;
    }

    public void Stop()
    {
        mIsRunning = false;
        mCurrentTime = 0f;
    }

    public bool IsStarted()
    {
        return mIsRunning;
    }

    public void Restart()
    {
        Stop();
        Start();
    }

    public float GetCurrentTime()
    {
        return mCurrentTime;
    }

    public float GetMaximumTime()
    {
        return mTimeBeforeEnd;
    }

    public bool IsTarget(object pObject)
    {
        return mCallback != null && mCallback.Target == pObject;
    }
}
