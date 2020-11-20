using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIObject : MonoBehaviour
{
    private UpgradeObject upgradeData;
    public Image icon;
    public Text upgradeName;
    public Text upgradeDescription;
    public Text currentCost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpgradeData(UpgradeObject pNewUpgradeData)
    {
        upgradeData = pNewUpgradeData;
        icon = upgradeData.icon;
        upgradeName.text = upgradeData.upgradeName;
        upgradeDescription.text = upgradeData.description;
        currentCost.text = upgradeData.baseCost.ToString(); //TODO raise this as the player purchases upgrades AND as when the player prefs are loaded with an existing key
    }
}
