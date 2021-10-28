using System;
using System.Collections.Generic;

[Serializable]
public class GameReport
{
    private ReportLevel _currentLevel;

    public DateTime Timestamp;
    public int ExpectedStages;
    public List<ReportLevel> Levels;

    public bool HasCurrentLevel => _currentLevel != null;

    public GameReport(int expectedStages)
    {
        Levels = new List<ReportLevel>();
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

    public void AddPoint(DateTime timestamp, double playerHeight, double pointHeight)
    {
        _currentLevel.AddPoint(timestamp, playerHeight, pointHeight);
    }
}
