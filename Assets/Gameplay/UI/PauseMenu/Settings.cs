using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private const string SHOW_VISUAL_KEYBOARD = "ShowKeyboard";
    public const string STARDUST_COUNT = "Stardust";

    private const string ERASE_SAVE_TEXT = "ERASE SAVE";
    private const string ERASE_CONFIRMATION = "ARE YOU SURE?";
    public GameObject m_VirtualKeyboard;
    public Toggle m_ShowKeyboardToggle;

    public Text m_EraseSaveButtonText;
    public Button m_EraseSaveButton;
    private bool hasConfirmedErasure = false;
    public StardustCounter m_StardustCounter;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(SHOW_VISUAL_KEYBOARD))
        {
            SetActiveVirtualKeyboard(PlayerPrefs.GetFloat(SHOW_VISUAL_KEYBOARD));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetActiveVirtualKeyboard(float pSetActive) // 0 means false
    {
        if(m_VirtualKeyboard!= null)
        {
            if(pSetActive == 0)
            {
                PlayerPrefs.SetFloat(SHOW_VISUAL_KEYBOARD, 0);
                m_VirtualKeyboard.SetActive(false);
                m_ShowKeyboardToggle.isOn = false;
            } else
            {
                PlayerPrefs.SetFloat(SHOW_VISUAL_KEYBOARD, 1);
                m_VirtualKeyboard.SetActive(true);
                m_ShowKeyboardToggle.isOn = true;
            }
        }
    }

    public void SetActiveVirtualKeyboard()
    {
        if(m_ShowKeyboardToggle.isOn)
        {
            SetActiveVirtualKeyboard(1);
        } else
        {
            SetActiveVirtualKeyboard(0);
        }
    }

    public void EraseSave()
    {
        if(!hasConfirmedErasure)
        {
            m_EraseSaveButtonText.text = ERASE_CONFIRMATION;
            hasConfirmedErasure = true;
        } else
        {
            ResetEraseButton();
            m_EraseSaveButton.interactable = false;
            EraseSettings();
        }
    }

    private void EraseSettings()
    {
        PlayerPrefs.DeleteKey(SHOW_VISUAL_KEYBOARD);
        PlayerPrefs.DeleteKey(STARDUST_COUNT);

        m_StardustCounter.EraseAllStardust();
        SetActiveVirtualKeyboard(1);
    }

    private void ResetEraseButton()
    {
        m_EraseSaveButton.interactable = true;
        m_EraseSaveButtonText.text = ERASE_SAVE_TEXT;
        hasConfirmedErasure = false;
    }

    public void EnableEraseButton()
    {
        m_EraseSaveButton.interactable = true;
    }
}
