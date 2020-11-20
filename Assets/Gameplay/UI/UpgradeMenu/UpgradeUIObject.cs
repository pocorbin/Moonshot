using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIObject : MonoBehaviour
{
    private const string LEVEL_PREFIX = "Lvl. ";

    private UpgradeObject upgradeData;
    public Image icon;
    public Text upgradeName;
    public Text upgradeDescription;
    private int currentLevel;
    public Text upgradeLevel;
    private float currentCost;
    public Text currentCostText;
    public Button upgradeButton;

    private StardustCounter mStardustCounter;
    private UpgradeList mUpgradeList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpgradeData(StardustCounter pStardustCounter, UpgradeList upgradeList, UpgradeObject pNewUpgradeData)
    {
        mStardustCounter = pStardustCounter;
        mUpgradeList = upgradeList;
        upgradeData = pNewUpgradeData;
        icon.sprite = upgradeData.icon;
        SetTexts();
        SetLevel();
        SetCost();
        SetButton();
    }

    private void SetTexts()
    {
        upgradeName.text = upgradeData.upgradeName;
        upgradeDescription.text = upgradeData.description;
    }

    private void SetLevel()
    {
        string upgradeKey = upgradeData.upgradeKey;
        if (!string.IsNullOrEmpty(upgradeKey) && PlayerPrefs.HasKey(upgradeKey))
        {
            currentLevel = PlayerPrefs.GetInt(upgradeData.upgradeKey);
        }
        else
        {
            currentLevel = 0;
        }
        upgradeLevel.text = LEVEL_PREFIX + currentLevel;
    }

    private void SetCost()
    {
        currentCost = upgradeData.baseCost;
        for(int i = 0; i < currentLevel; i++)
        {
            currentCost = currentCost + (upgradeData.incrementRate / 100 * currentCost);
        }
        currentCost = Mathf.CeilToInt(currentCost);
        currentCostText.text = currentCost.ToString() + "x"; //TODO raise this as the player purchases upgrades AND as when the player prefs are loaded with an existing key
    }

    public void SetButton() //Is called by the list every time an upgrade is made
    {
        if (upgradeData.baseCost == 0 || !mStardustCounter.CanSpendStardust(currentCost))
        {
            upgradeButton.interactable = false;
        }
    }

    public void Upgrade()
    {
        if(mStardustCounter.CanSpendStardust(currentCost))
        {
            mStardustCounter.SpendStardust(currentCost);
            currentLevel++;
            PlayerPrefs.SetInt(upgradeData.upgradeKey, currentLevel);
            SetLevel();
            SetCost();

            mUpgradeList.UpdateUpgradeButtons();
        }
    }
}
