using System;

public static class ReportManager
{
    private static GameReport _currentGameReport;

    public static GameReport GetCurrentGameReport() => _currentGameReport;

    public static void CreateGameReport(int expectedStages)
    {
        _currentGameReport = new GameReport(expectedStages);
    }

    public static void AddLevel(Level level)
    {
        _currentGameReport?.AddLevel(level.Stage, level.StartTime.GetValueOrDefault());
    }

    public static void EndLevel(DateTime endTime)
    {
        if (_currentGameReport?.HasCurrentLevel ?? false)
            _currentGameReport.EndLevel(endTime);
    }

    public static void AddPoint()
    {
        _currentGameReport?.AddPoint(DateTime.Now);
    }

    public static void LogHeight(double height, DateTime gameStartDateTime)
    {
        FileManager.LogHeight(height, gameStartDateTime);
    }
}
