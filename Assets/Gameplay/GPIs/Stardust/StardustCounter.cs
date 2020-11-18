using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StardustCounter : MonoBehaviour
{
    private float SINGLE_INCREMENT_TIME = 0.01f;
    private int BASE_NUMBER_OF_INCREMENTS = 40;
    public Text m_StardustCountText;

    private float currentStardustCount = 0; //This helps me track how much is displayed during an animation
    private float targetStardustCount = 0;

    private TimerManager timerManager;
    private Timer singleIncrementTimer;
    private Action IncrementOnceCallback;

    private float incrementRate = 0;//Can be negative
    private int numberOfIncrementsLeft = 0;

    // Start is called before the first frame update
    void Start()
    {
        timerManager = GetComponent<TimerManager>();
        IncrementOnceCallback += IncrementOnce;
        singleIncrementTimer = timerManager.CreateTimer(SINGLE_INCREMENT_TIME, true, IncrementOnceCallback);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseStardustCount(float pIncreaseAmount)
    {
        targetStardustCount += pIncreaseAmount;
        AnimateText();
    }

    public void DecreaseStardustCount(int pDecreaseAmount)
    {
        targetStardustCount -= pDecreaseAmount;
        AnimateText();
    }

    private void AnimateText()
    {
        numberOfIncrementsLeft = BASE_NUMBER_OF_INCREMENTS;
        DetermineIncrementRate();

        if (!singleIncrementTimer.IsStarted())//There is no ongoing animation
        {
            singleIncrementTimer.Restart();
        }
    }

    private void DetermineIncrementRate()
    {
        float difference = targetStardustCount - currentStardustCount;
        difference = Mathf.Abs(difference);
        incrementRate = difference / numberOfIncrementsLeft;
        if(targetStardustCount< currentStardustCount)
        {
            incrementRate = incrementRate * -1;
        }
    }

    private void UpdateText()
    {
        m_StardustCountText.text = "x" + Mathf.RoundToInt(currentStardustCount);
    }

    private void IncrementOnce()
    {
        currentStardustCount += incrementRate;
        UpdateText();
        numberOfIncrementsLeft--;
        if(numberOfIncrementsLeft == 0)
        {
            singleIncrementTimer.Stop();
        }
    }
}
