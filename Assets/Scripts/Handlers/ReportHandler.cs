using UnityEngine;

public class ReportHandler : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("SaveCurrentHeight", 1f, 1f);
    }

    void SaveCurrentHeight()
    {
        ReportManager.LogHeight(PlayerMoviment.CurrentPlatformHeight, GameHandler.GameStartDateTime);
    }

    void OnApplicationQuit()
    {
        GameHandler.GetInstance().SaveGameReport();
    }
}
