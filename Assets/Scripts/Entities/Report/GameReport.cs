using Newtonsoft.Json;
using System;
using System.Collections.Generic;

[Serializable]
public class GameReport
{
    private ReportLevel _currentLevel;

    public DateTime Timestamp { get; protected set; }
    public int ExpectedStages { get; protected set; }
    public List<ReportLevel> Levels { get; protected set; } = new List<ReportLevel>();

    [JsonIgnore]
    public bool HasCurrentLevel => _currentLevel != null;

    public GameReport(int expectedStages)
    {
        Timestamp = DateTime.Now;
        ExpectedStages = expectedStages;
    }

    public void AddLevel(int stage, DateTime startTime)
    {
        var newLevel = new ReportLevel(stage, startTime);

        Levels.Add(newLevel);
        _currentLevel = newLevel;
    }

    public void EndLevel(DateTime endTime)
    {
        _currentLevel.EndLevel(endTime);
    }

    public void AddPoint(DateTime timestamp)
    {
        _currentLevel.AddPoint(timestamp);
    }
}
