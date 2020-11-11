using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargingOverlay : MonoBehaviour
{
    private Image chargingImageOverlay;
    private Timer timerToTrack;
    // Start is called before the first frame update
    void Start()
    {
        chargingImageOverlay = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFill();
    }

    public void SetTimerToTrack(Timer pTimerToTrack)
    {
        timerToTrack = pTimerToTrack;
    }

    public void StopFilling()
    {
        timerToTrack = null;
    }

    private void UpdateFill()
    {
        float fill = 0f;
        if (chargingImageOverlay != null & timerToTrack != null && timerToTrack.IsStarted())
        {
            fill = timerToTrack.GetCurrentTime() / timerToTrack.GetMaximumTime();
            chargingImageOverlay.fillAmount = fill;
        } else if(timerToTrack == null)
        {
            chargingImageOverlay.fillAmount = fill;
        }
    }
}
