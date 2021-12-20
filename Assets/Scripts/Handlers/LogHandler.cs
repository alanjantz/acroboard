using UnityEngine;

public class LogHandler : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("SaveCurrentStatus", 1f, 1f);
    }

    void SaveCurrentStatus()
    {
        ReportManager.LogStatus(
            GameHandler.GameStartTime,
            Platform.CurrentPlatformHeight,
            PlayerStatusReport.GetPlayerLookingDirection(
                Camera.main.transform.rotation.eulerAngles.x)
            );
    }

    void OnApplicationQuit()
    {
        GameHandler.GetInstance().SaveGameReport();
    }
}
