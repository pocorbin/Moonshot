using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailedAnnouncement : MonoBehaviour
{
    private const string DISPLAY_TRIGGER = "Display";
    private const string HIDE_TRIGGER = "Hide";
    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Display()
    {
        mAnimator.SetTrigger(DISPLAY_TRIGGER);
    }

    public void Restart()
    {
        mAnimator.SetTrigger(HIDE_TRIGGER);
    }
}
