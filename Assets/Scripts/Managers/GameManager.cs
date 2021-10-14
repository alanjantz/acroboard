using System;

public static class GameManager
{
    public static Game CurrentGame { get; private set; }
    public static Level CurrentLevel => CurrentGame?.CurrentLevel;
    public static bool Active { get; private set; }
    public static bool Playing => !(CurrentGame?.Paused).GetValueOrDefault();

    private static float _currentPointValue = 5f;

    public static void CreateNewGame(DateTime start)
    {
        Reset();
        CurrentGame = new Game(start, LevelGenerator.Genetare(1));
        Active = true;
    }

    public static void EndCurrentGame()
    {
        if (Active)
            Active = false;
    }

    public static void AddPoint() => AddPoints(1);
    public static void AddPoints(int amount) => CurrentGame.AddPoints(amount, _currentPointValue);
    public static void IncreasePointValue(float pointValue) => _currentPointValue += pointValue;

    private static void Reset()
    {
        _currentPointValue = 5f;
    }

    public static void CreateGameReportFile()
    {
        var reportPath = FileManager.CreateGameReportFile(ReportManager.GetCurrentGameReport(), CurrentGame.StartTime);

        CurrentGame.ReportPath = reportPath;
    }
}
