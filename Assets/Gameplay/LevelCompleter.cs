using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleter : MonoBehaviour
{
    private int asteroidsToTrack = 0;
    private Action destroyedAsteroid;
    private Action destroyedEarth;

    private bool levelHasBegun = false;

    public LevelCompleteAnnouncement levelCompleteAnnouncement;

    private Earth earth;

    private int levelsCompleted = 0;
    // Start is called before the first frame update
    void Start()
    {
        destroyedAsteroid += OnDestroyedAsteroid;
        destroyedEarth += OnDestroyedEarth;
        earth = GetComponent<Earth>();
        earth.SetOnDestroyedCallback(destroyedEarth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Action GetDestroyedAsteroidCallback()
    {
        return destroyedAsteroid;
    }

    public void InitializeLevel(int numberOfAsteroidsToTrack)
    {
        levelHasBegun = true;
        asteroidsToTrack = numberOfAsteroidsToTrack;
    }

    private void CheckEnd()
    {
        if(levelHasBegun && asteroidsToTrack == 0)
        {
            levelsCompleted++;
            levelHasBegun = false;
            levelCompleteAnnouncement.ShowAnnouncement(levelsCompleted);
        }
        //TODO watchout if the last destroyed asteroid also destroyed earth!
    }

    private void OnDestroyedAsteroid()
    {
        asteroidsToTrack--;
        CheckEnd();
    }

    private void OnDestroyedEarth()
    {
        levelHasBegun = false;
        Debug.Log("Game is over");
        GetRidOfAsteroids();
    }

    private void GetRidOfAsteroids()
    {
        //TODO improve this so it does as designed
    }
}
