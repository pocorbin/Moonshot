using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeList : MonoBehaviour
{
    public StardustCounter m_StardustCounter;
    public UpgradeUIObject m_UpgradeUIPrefab;
    public List<UpgradeObject> m_UpgradesToShow = new List<UpgradeObject>();
    private List<UpgradeUIObject> m_DisplayedUpgrades = new List<UpgradeUIObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    public void InitializeList()
    {
        ResetList();
        foreach(var upgrade in m_UpgradesToShow)
        {
            Debug.Log("Initializing list");
            UpgradeUIObject temp = Instantiate(m_UpgradeUIPrefab, this.transform);
            temp.SetUpgradeData(m_StardustCounter, this, upgrade);
            m_DisplayedUpgrades.Add(temp);
        }
    }

    private void ResetList()
    {
        foreach (var upgrade in m_DisplayedUpgrades)
        {
            Destroy(upgrade.gameObject);
        }
        m_DisplayedUpgrades = new List<UpgradeUIObject>();
    }

    public void UpdateUpgradeButtons()
    {
        foreach (var upgrade in m_DisplayedUpgrades)
        {
            upgrade.SetButton();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
