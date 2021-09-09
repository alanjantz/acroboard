using Google.XR.Cardboard;
using UnityEngine;

public class CardboardStartup : MonoBehaviour
{
    public void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;

        // Checks if the device parameters are stored and scans them if not.
        if (!Api.HasDeviceParams())
        {
            Api.ScanDeviceParams();
        }
    }

    public void Update()
    {
        if (Api.IsGearButtonPressed)
        {
            Api.ScanDeviceParams();
        }

        if (Api.IsCloseButtonPressed)
        {
            Application.Quit();
        }

        if (Api.HasNewDeviceParams())
        {
            Api.ReloadDeviceParams();
        }

        Api.UpdateScreenParams();
    }
}
