using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LevelCompleteAnnouncement : MonoBehaviour
{
    private const string TEXT_PART_1 = "Level ";
    private const string TEXT_PART_2 = " starts in ";
    private const string SLIDE_IN_TRIGGER = "SlideIn";
    private const string SLIDE_OUT_TRIGGER = "SlideOut";

    public TextMeshPro textToEdit;
    private TimerManager timerManager;
    private Timer countdownTimer;
    private Action onTimerEnd;
    private int secondsLeft = 3;
    private Animator mAnimator;

    private int nextLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        onTimerEnd += OnTimerEnd;
        timerManager = GetComponent<TimerManager>();
        mAnimator = GetComponent<Animator>();
        countdownTimer = timerManager.CreateTimer(1f, true, onTimerEnd);
        WriteNextLevelText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowAnnouncement(int pLevelCompleted)
    {
        nextLevel = pLevelCompleted;
        mAnimator.SetTrigger(SLIDE_IN_TRIGGER);
    }

    public void StartCountdown()
    {
        countdownTimer.Restart();
    }

    private void OnTimerEnd()
    {
        secondsLeft--;
        WriteNextLevelText();
        if(secondsLeft == 0)
        {
            countdownTimer.Stop();
            mAnimator.SetTrigger(SLIDE_OUT_TRIGGER);
        }
    }

    private void WriteNextLevelText()
    {
        textToEdit.text = TEXT_PART_1 + nextLevel.ToString() + TEXT_PART_2 + secondsLeft.ToString();
    }
}
