using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stardust : MonoBehaviour
{
    public const string STARDUST_TAG = "Stardust";

    private Vector2 TOP_CURVE_SECOND_POINT = new Vector2(0, 5);
    private Vector2 TOP_CURVE_THIRD_POINT = new Vector2(-5.3f, 4.5f);

    private Vector2 BOT_CURVE_SECOND_POINT = new Vector2(-8.88f, 0);
    private Vector2 BOT_CURVE_THIRD_POINT = new Vector2(-8.3f, 2.5f);

    private Vector2 STARDUST_COUNTER_POSITION = new Vector2(-8, 4);

    public float m_Delay = 0.5f;
    private MoveToPositionOverTime mover;
    private TimerManager timerManager;
    private Timer movementDelayTimer;
    private Action startMovingCallback;
    public float value = 0f;

    public ParticleSystem initialExplosion;

    private BezierRoute route;
    private List<Vector3> controlPointsList = new List<Vector3>();

    private List<Vector3> waypoints = new List<Vector3>();
    private int nextWaypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        startMovingCallback += StartMoving;
        route = GetComponent<BezierRoute>();
        mover = GetComponent<MoveToPositionOverTime>();
        timerManager = GetComponent<TimerManager>();
        movementDelayTimer = timerManager.CreateTimer(m_Delay, false, startMovingCallback);
        movementDelayTimer.Start();
        DetermineWhichRouteToUse();
        Instantiate(initialExplosion, this.transform.position, initialExplosion.transform.rotation, this.transform.parent);
    }

    private void StartMoving()
    {
       mover.enabled = true;
    }

    private void Update()
    {
        UpdateTrajectory();
    }

    private void UpdateTrajectory()
    {
        if(waypoints.Count > 0 && mover.enabled == true)
        {
            float distance = Vector3.Distance(this.transform.position, waypoints[nextWaypointIndex]);
            if (distance < 0.0001f)
            {
                if (nextWaypointIndex < waypoints.Count-1)
                {
                    nextWaypointIndex++;
                    mover.m_TargetPosition = waypoints[nextWaypointIndex];
                }
            }
        }
    }

    private void DetermineWhichRouteToUse()
    {
        float angle = Vector2.SignedAngle(this.transform.position, STARDUST_COUNTER_POSITION);
        controlPointsList.Add(this.transform.position);
        
        if (angle >=0)
        {
            controlPointsList.Add(TOP_CURVE_SECOND_POINT);
            controlPointsList.Add(TOP_CURVE_THIRD_POINT);
        } else
        {
            controlPointsList.Add(BOT_CURVE_SECOND_POINT);
            controlPointsList.Add(BOT_CURVE_THIRD_POINT);
        }
        controlPointsList.Add(STARDUST_COUNTER_POSITION);
        waypoints = route.GetWayPoints(controlPointsList);
        mover.m_TargetPosition = waypoints[0];
    }
}
