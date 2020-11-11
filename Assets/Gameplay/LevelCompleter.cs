using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleter : MonoBehaviour
{
    private List<SpaceObject> spaceObjectsToTrack = new List<SpaceObject>();
    private Action<Asteroid> destroyedAsteroid;
    private Action destroyedEarth;

    public LevelCompleteAnnouncement levelCompleteAnnouncement;
    public LevelFailedAnnouncement levelFailedAnnouncement;

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
    
    public Action<Asteroid> GetDestroyedAsteroidCallback()
    {
        return destroyedAsteroid;
    }

    public void InitializeLevel(List<SpaceObject> pSpaceObjectsToTrack)
    {
        spaceObjectsToTrack = pSpaceObjectsToTrack;
        earthIsDestroyed = false;
    }

    private void CheckEnd()
    {
        if (!earthIsDestroyed && spaceObjectsToTrack.Count == 0)
        {
            levelsCompleted++;
            levelCompleteAnnouncement.ShowAnnouncement(levelsCompleted);
        } else if (earthIsDestroyed && spaceObjectsToTrack.Count == 0)
        {
            //Last space object has crashed into the earth
            earth.FallOff();
            levelsCompleted++;
            levelFailedAnnouncement.Display(levelsCompleted);
            levelsCompleted = 0;
        }
    }

    private void OnDestroyedAsteroid(Asteroid pDestroyedAsteroid)
    {
        spaceObjectsToTrack.Remove(pDestroyedAsteroid);
        CheckEnd();
    }

    private void OnDestroyedEarth()
    {
        earthIsDestroyed = true;
        GetRidOfSpaceObjects();
    }

    private void GetRidOfSpaceObjects()
    {
        //TODO improve this so it does as designed
        foreach(var spaceObject in spaceObjectsToTrack)
        {
            spaceObject.CrashIntoTarget();
        }
    }

    public int GetCurrentLevel()
    {
        return levelsCompleted;
    }
}
