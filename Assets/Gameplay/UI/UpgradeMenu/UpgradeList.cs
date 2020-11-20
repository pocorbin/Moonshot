using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeList : MonoBehaviour
{
    public UpgradeUIObject m_UpgradeUIPrefab;
    public List<UpgradeObject> m_UpgradesToShow = new List<UpgradeObject>();
    // Start is called before the first frame update
    void Start()
    {
        InitializeList();
    }

    private void InitializeList()
    {
        foreach(var upgrade in m_UpgradesToShow)
        {
            UpgradeUIObject temp = Instantiate(m_UpgradeUIPrefab);
            temp.SetUpgradeData(upgrade);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
