using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public static class FileManager
{
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
        string path = $"{GetFolderPath(timestamp)}/player-status.log";
        var status = new PlayerStatusReport(timestamp, height, playerLookingDirection);

        string content = $"{JsonUtility.ToJson(status)}{Environment.NewLine}";

        if (!File.Exists(path))
            File.WriteAllText(path, content);
        else
            File.AppendAllText(path, content);
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
