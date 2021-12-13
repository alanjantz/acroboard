using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public static class FileManager
{
    private const string PLAYER_STATUS_HEADER = "Timestamp;Height;LookingDirection;LookingDirectionDescription";

    public static string CreateGameReportFile(GameReport report, DateTime timestamp)
    {
        string path = $"{GetFolderPath(timestamp)}/game-report.json";
        string content = JsonUtility.ToJson(report, true);

        if (!File.Exists(path))
            File.WriteAllText(path, content);

        return path;
    }

    public static void LogPlayerStatus(DateTime timestamp, double height, PlayerLookingDirection playerLookingDirection)
    {
        string path = $"{GetFolderPath(timestamp)}/player-status.csv";
        var status = new PlayerStatusReport(timestamp, height, playerLookingDirection);

        string content = $"{DateTime.Now:s};{status.Height};{(int)status.LookingDirection};{status.LookingDirection.GetStringValue()}";

        if (!File.Exists(path))
            File.WriteAllText(path, PLAYER_STATUS_HEADER + Environment.NewLine);

        File.AppendAllText(path, content + Environment.NewLine);
    }

    private static string GetFolderPath(DateTime dateTime)
    {
        var folderPath = $"{AcroboardConfiguration.FilesPath}/{GetFolderName(dateTime)}";

        CreateFolder(folderPath);

        return folderPath;
    }

    private static string GetFolderName(DateTime dateTime)
        => Regex.Replace(dateTime.ToString("s"), "[^0-9.]", string.Empty);

    private static void CreateFolder(string folderPath)
    {
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);
    }
}
