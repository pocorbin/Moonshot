﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPositionOverTime : MonoBehaviour
{
    public Vector3 m_TargetPosition = Vector3.zero;
    public float m_Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(m_TargetPosition.x, m_TargetPosition.y, m_TargetPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, newPos, m_Speed * Time.deltaTime);
    }
}