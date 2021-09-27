using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public static class FileManager
{
    public static void CreateReportFile(Report report)
    {
        string path = $"{Application.persistentDataPath}/{GetFileName()}.json";
        string content = JsonConvert.SerializeObject(report, Formatting.Indented);

        if (!File.Exists(path))
            File.WriteAllText(path, content);
    }

    private static string GetFileName()
        => Regex.Replace(DateTime.Now.ToString("s"), "[^0-9.]", string.Empty);
}
