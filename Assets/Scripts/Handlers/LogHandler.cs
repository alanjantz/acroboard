using UnityEngine;

public class LogHandler : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("SaveCurrentHeight", 1f, 1f);
    }

    void SaveCurrentHeight()
    {
        ReportManager.LogHeight(Platform.CurrentPlatformHeight, GameHandler.GameStartTime);
    }

    void OnApplicationQuit()
    {
        GameHandler.GetInstance().SaveGameReport();
    }
}
