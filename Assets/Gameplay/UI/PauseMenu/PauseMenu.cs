using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if(Time.timeScale == 0)
        {
            Resume();
        } else
        {
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        Display();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Hide();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Display()
    {
        mAnimator.SetTrigger(DISPLAY_TRIGGER);
    }

    public void Hide()
    {
        mAnimator.SetTrigger(HIDE_TRIGGER);
    }
}
