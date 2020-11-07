using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public Moon m_Moon;
    private Earth earth;
    public int difficultyLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        earth = GetComponent<Earth>();
        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel()
    {
        m_Moon.Spawn();
        if(earth.IsDestroyed())
        {
            earth.Spawn();
        }
    }
}
