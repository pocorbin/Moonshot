using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpArrowTutorial : MonoBehaviour
{
    public const string HAS_CLEARED_TUTORIAL = "TutorialCleared";
    private const string DISPLAY_TRIGGER = "Display";
    private const string HIDE_TRIGGER = "Hide";

    private Animator mAnimator;
    public ChargingCanon m_TopCannon;
    
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        if (PlayerPrefs.HasKey(HAS_CLEARED_TUTORIAL) && PlayerPrefs.GetInt(HAS_CLEARED_TUTORIAL) == 1)
        {
            HideForever();
        } else
        {
            Display();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
    }

    private void Animate()
    {
        if(m_TopCannon.IsCharging())
        {
            Hide();
        } else
        {
            Display();
        }
        if(m_TopCannon.IsShotReady())
        {
            HideForever();
        }
    }

    private void Hide()
    {
        mAnimator.SetTrigger(HIDE_TRIGGER);
    }

    private void HideForever()
    {
        Hide();
        PlayerPrefs.SetInt(HAS_CLEARED_TUTORIAL,1);
        this.gameObject.SetActive(false);
    }

    private void Display()
    {
        mAnimator.SetTrigger(DISPLAY_TRIGGER);
    }
}
