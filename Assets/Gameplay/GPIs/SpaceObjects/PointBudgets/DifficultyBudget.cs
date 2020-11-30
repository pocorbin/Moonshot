using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyBudget", menuName = "ScriptableObjects/DifficultyBudget", order = 1)]
public class DifficultyBudget : ScriptableObject
{
    public float baseMin = 0f;
    public float baseMax = 0f;
    public float minIncrementationPerLevel = 0f;
    public float maxIncrementationPerLevel = 0f;
    public float cost = 1f;
    public float incrementRate = 1f;
    public float absoluteMaximum = 0;

    public float GetMinValue(int currentLevel)
    {
        return baseMin + (minIncrementationPerLevel*currentLevel);
    }

    public float GetMaxValue(int currentLevel)
    {
        return Mathf.Min(baseMax + (maxIncrementationPerLevel * currentLevel),absoluteMaximum);
    }
}
