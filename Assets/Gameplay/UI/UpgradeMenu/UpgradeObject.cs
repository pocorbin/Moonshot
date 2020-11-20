using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UpgradeObject", menuName = "ScriptableObjects/UpgradeObject", order = 1)]
public class UpgradeObject : ScriptableObject
{
    public Image icon;
    public string upgradeName = "Upgrade Name";
    public string description = "Upgrade Description";
    public float baseCost = 100f;
    public float incrementRate = 10f;
}
