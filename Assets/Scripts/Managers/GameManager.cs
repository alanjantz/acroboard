using System;
using UnityEngine;

public static class GameManager
{
    public static Game CurrentGame { get; private set; }
    public static Level CurrentLevel => CurrentGame?.CurrentLevel;
    public static bool Paused { get; private set; }
    public static bool Playing => !Paused;
    public static bool GameEnded { get; private set; }

    private static float _currentPointValue = 5f;

    public static void CreateNewGame(DateTime start)
    {
        Reset();
        CurrentGame = new Game(start, LevelGenerator.Genetare(AcroboardConfiguration.LevelsAmount));
    }

    public static void Pause() => Paused = true;
    public static void Resume()=> Paused = false;
    public static void EndGame()
    {
        Pause();
        GameEnded = true;
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
