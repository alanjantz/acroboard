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

    public static void AddPoint(double playerHeight, double pointHeight)
    {
        _currentGameReport?.AddPoint(DateTime.Now, playerHeight, pointHeight);
    }

    public static void LogStatus(DateTime gameStartDateTime, double height, PlayerLookingDirection playerLookingDirection)
    {
        FileManager.LogPlayerStatus(gameStartDateTime, height, playerLookingDirection);
    }
}
