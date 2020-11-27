using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldCounter : MonoBehaviour
{
    private const int MAX_CHARGES_TO_DISPLAY = 5;
    public UpgradeObject m_ShieldUpgrade;
    public GameObject m_ChargeContainer;
    public GameObject m_ShieldChargeIcon;
    public Image m_Background;
    public Text m_TextCharges;

    private int currentCharges = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        if (PlayerPrefs.HasKey(m_ShieldUpgrade.upgradeKey) && PlayerPrefs.GetInt(m_ShieldUpgrade.upgradeKey) > 0)
        {
            currentCharges = PlayerPrefs.GetInt(m_ShieldUpgrade.upgradeKey);
            Display();
        } else
        {
            Hide();
        }
    }

    private void Hide()
    {
        m_Background.enabled = false;
    }

    private void Display()
    {
        m_Background.enabled = true;
        DisplayCharges();
    }

    public void LoseCharge()
    {
        currentCharges--;
        DisplayCharges();
        if(currentCharges == 0)
        {
            Hide();
        }
    }

    private void DisplayCharges()
    {
        RemoveAllChargeVisuals();
        if(currentCharges <= MAX_CHARGES_TO_DISPLAY)
        {
            for (int i = 0; i < currentCharges; i++)
            {
                Instantiate(m_ShieldChargeIcon, m_ChargeContainer.transform);
            }
        } else
        {
            m_TextCharges.text = "x" + currentCharges.ToString();
            m_TextCharges.enabled = true;
            //TODO write charges textually
        }
    }

    private void RemoveAllChargeVisuals()
    {
        m_TextCharges.enabled = false;
        for(int i = 0; i < m_ChargeContainer.transform.childCount; i++)
        {
            Destroy(m_ChargeContainer.transform.GetChild(i).gameObject);
        }
    }
}
