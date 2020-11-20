using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFailedAnnouncement : MonoBehaviour
{
    private const string TITLE_FIRST_PART = "Level ";
    private const string TITLE_SECOND_PART = " failed!";
    private const string DISPLAY_TRIGGER = "Display";
    private const string HIDE_TRIGGER = "Hide";
    private const string INSTANT_HIDE_TRIGGER = "InstantHide";
    private Animator mAnimator;
    public Text mTitleText;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Display(int failedLevel)
    {
        mTitleText.text = TITLE_FIRST_PART + failedLevel.ToString() + TITLE_SECOND_PART;
        mAnimator.SetTrigger(DISPLAY_TRIGGER);
    }

    public void Next()
    {
        mAnimator.SetTrigger(INSTANT_HIDE_TRIGGER);
    }
}
