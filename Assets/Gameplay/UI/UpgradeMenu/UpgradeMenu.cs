using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    private const string INSTANT_DISPLAY_TRIGGER = "InstantDisplay";
    private const string HIDE_TRIGGER = "Hide";
    private Animator mAnimator;

    public UpgradeList m_UpgradeList;
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
        m_UpgradeList.InitializeList();
        mAnimator.SetTrigger(INSTANT_DISPLAY_TRIGGER);
    }

    public void Restart()
    {
        mAnimator.SetTrigger(HIDE_TRIGGER);
    }
}
