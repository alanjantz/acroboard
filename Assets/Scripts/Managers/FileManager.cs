using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public static class FileManager
{
    public static void CreateGameReportFile(GameReport report, DateTime gameStartDateTime)
    {
        string path = $"{GetFolderPath(gameStartDateTime)}/game-report.json";
        string content = JsonConvert.SerializeObject(report, Formatting.Indented);

        if (!File.Exists(path))
            File.WriteAllText(path, content);
    }

    public static void LogHeight(double height, DateTime gameStartDateTime)
    {
        string path = $"{GetFolderPath(gameStartDateTime)}/height-log.json";
        string content = $"{DateTime.Now} - {height:0.##}m{Environment.NewLine}";

        if (!File.Exists(path))
            File.WriteAllText(path, content);
        else
            File.AppendAllText(path, content);
    }

    private static string GetFolderPath(DateTime dateTime)
    {
        var folderPath = $"{Application.persistentDataPath}/{GetFolderName(dateTime)}";

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
