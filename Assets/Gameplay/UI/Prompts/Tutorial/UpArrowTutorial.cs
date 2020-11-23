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
    public Canon m_TopCannon;

    private Action mHideForeverCallback;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        if(m_TopCannon != null)
        {
            mHideForeverCallback += HideForever;
            m_TopCannon.SetShootCallback(mHideForeverCallback);
        }
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
        HideWhenHeld();
    }

    private void HideWhenHeld()
    {
        for(int i = 0; i < m_TopCannon.m_KeysToPress.Count; i++)
        {
            if (Input.GetKeyDown(m_TopCannon.m_KeysToPress[i]))
            {
                Hide();
            }
            if (Input.GetKeyUp(m_TopCannon.m_KeysToPress[i]))
            {
                Display();
            }
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
