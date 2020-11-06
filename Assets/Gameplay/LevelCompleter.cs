using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleter : MonoBehaviour
{
    private int asteroidsToTrack = 0;
    private Action destroyedAsteroid;

    private bool levelHasBegun = false;

    public LevelCompleteAnnouncement levelCompleteAnnouncement;

    private int levelsCompleted = 0;
    // Start is called before the first frame update
    void Start()
    {
        destroyedAsteroid += OnDestroyedAsteroid;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Action GetDestroyedAsteroidCallback()
    {
        return destroyedAsteroid;
    }

    public void InitializeLevel(int numberOfAsteroids)
    {
        levelHasBegun = true;
        asteroidsToTrack = numberOfAsteroids;
    }

    private void CheckEnd()
    {
        if(levelHasBegun && asteroidsToTrack == 0)
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
}
