using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleter : MonoBehaviour
{
    private int asteroidsToTrack = 0;
    private Action destroyedAsteroid;
    private Action destroyedEarth;

    public LevelCompleteAnnouncement levelCompleteAnnouncement;

    private Earth earth;

    private int levelsCompleted = 0;

    private bool earthIsDestroyed = false;
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
        asteroidsToTrack = numberOfAsteroidsToTrack;
        earthIsDestroyed = false;
    }

    private void CheckEnd()
    {
        if(!earthIsDestroyed && asteroidsToTrack == 0)
        {
            levelsCompleted++;
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
        Debug.Log("Game is over");
        earthIsDestroyed = true;
        GetRidOfAsteroids();
    }

    private void GetRidOfAsteroids()
    {
        //TODO improve this so it does as designed
    }
}
