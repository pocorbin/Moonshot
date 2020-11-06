using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleter : MonoBehaviour
{
    private int asteroidsToTrack = 0;
    private Action destroyedAsteroid;

    private bool levelHasBegun = false;
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
            Debug.Log("Level is ended");
        }
        //TODO watchout if the last destroyed asteroid also destroyed earth!
    }

    private void OnDestroyedAsteroid()
    {
        asteroidsToTrack--;
        CheckEnd();
    }
}
